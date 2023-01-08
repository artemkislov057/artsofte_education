using System.Collections.Concurrent;
using System.Reflection;
using Education.Applications.Main.Model.Exceptions;
using Education.Applications.Main.Model.Extensions;
using Education.Applications.Main.Model.Models.Lessons;
using Education.DataBase.Entities;
using Education.DataBase.Entities.Lessons;
using Education.DataBase.Enums.Lessons;
using Education.DataBase.Extensions;
using Education.DataBase.Repositories;
using Mapster;

namespace Education.Applications.Main.Model.Services;

public interface ILessonsService
{
    Task<int[]> PostLessons(Guid courseId, Guid moduleId, IEnumerable<LessonContent> lessons);
    Task<LessonContent[]> GetLessons(Guid courseId, Guid moduleId);
    Task<bool> TryDeleteLesson(Guid courseId, Guid moduleId, int lessonId);
    Task EditLesson(Guid courseId, Guid moduleId, int lessonId, LessonContent lessonModel);
    Task ChangeOrder(Guid courseId, Guid moduleId, int[] orderIds);
}

public class LessonsService : ILessonsService
{
    private readonly ILessonsRepository lessonsRepository;
    private readonly IModulesRepository modulesRepository;
    private static readonly ConcurrentDictionary<LessonType, Type> ModelTypesByEntity = new();

    public LessonsService(ILessonsRepository lessonsRepository, IModulesRepository modulesRepository)
    {
        this.lessonsRepository = lessonsRepository;
        this.modulesRepository = modulesRepository;
    }

    public async Task<int[]> PostLessons(Guid courseId, Guid moduleId, IEnumerable<LessonContent> lessons)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            throw new NotMatchException("курс", courseId, "модуль", moduleId);
        }

        var entityLessons = lessons.Select(lesson =>
        {
            var entityLessonDetails = MapLessonDetailsEntityFromModel(lesson);
            var entityLesson = new Lesson
                { Type = entityLessonDetails.GetLessonType(), ModuleId = moduleId };
            lesson.Adapt(entityLesson);
            entityLesson.SetLessonDetails(entityLessonDetails);
            return entityLesson;
        }).ToArray();

        var lastLessonOrder = await lessonsRepository.FindLastLessonIdInModule(moduleId) ?? -1;
        await lessonsRepository.AddLessons(entityLessons.OrderElements(lastLessonOrder + 1));
        return entityLessons.Select(l => l.Id).ToArray();
    }

    public async Task<LessonContent[]> GetLessons(Guid courseId, Guid moduleId)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            throw new NotMatchException("курс", courseId, "модуль", moduleId);
        }

        var entityLessons = await lessonsRepository.GetLessons(moduleId);
        var models = entityLessons.Select(MapLessonContentFromEntity);
        return models.ToArray();
    }

    public async Task<bool> TryDeleteLesson(Guid courseId, Guid moduleId, int lessonId)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            throw new NotMatchException("курс", courseId, "модуль", moduleId);
        }

        var lesson = await lessonsRepository.FindLesson(lessonId, false);
        if (lesson is null)
        {
            return false;
        }

        if (lesson.ModuleId != moduleId)
        {
            throw new NotMatchException("модуль", moduleId, "урок", lessonId);
        }

        await lessonsRepository.DeleteLesson(lesson);
        return true;
    }

    public async Task EditLesson(Guid courseId, Guid moduleId, int lessonId, LessonContent lessonModel)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            throw new NotMatchException("курс", courseId, "модуль", moduleId);
        }

        var entityLesson = await lessonsRepository.FindLesson(lessonId);
        if (entityLesson is null)
        {
            throw new NotFoundException("урок", lessonId);
        }

        if (entityLesson.ModuleId != moduleId)
        {
            throw new NotMatchException("модуль", moduleId, "урок", lessonId);
        }

        var entityLessonDetailsFromModel = MapLessonDetailsEntityFromModel(lessonModel);
        var currentLessonDetails = entityLesson.GetLessonDetails();
        entityLesson.Name = lessonModel.Name;
        entityLesson.AdditionalText = lessonModel.AdditionalText?.Adapt<EditorJsObject>();
        if (entityLesson.Type != entityLessonDetailsFromModel.GetLessonType())
        {
            entityLesson.Type = entityLessonDetailsFromModel.GetLessonType();
            await lessonsRepository.ChangeLessonDetails(entityLesson, currentLessonDetails,
                entityLessonDetailsFromModel);
        }
        else
        {
            lessonModel.Adapt(currentLessonDetails, lessonModel.GetType(), lessonModel.EntityType);
            await lessonsRepository.EditLessonDetails(currentLessonDetails);
        }
    }

    public async Task ChangeOrder(Guid courseId, Guid moduleId, int[] orderIds)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            throw new NotMatchException("курс", courseId, "модуль", moduleId);
        }

        var lessons = await lessonsRepository.GetLessons(moduleId);
        lessons.ChangeOrder(orderIds);
        await lessonsRepository.EditLessons(lessons);
    }

    public static LessonContent MapLessonContentFromEntity(Lesson entityLesson)
    {
        var lessonContentType = GetLessonContentTypeByEntity(entityLesson.Type);
        var entityLessonDetails = entityLesson.GetLessonDetails();
        if (entityLessonDetails is null)
        {
            var res = (LessonContent)Activator.CreateInstance(lessonContentType)!;
            entityLesson.Adapt(res);
            return res;
        }
        var entityLessonDetailsType = entityLessonDetails.GetType();
        var lessonContentModel = (LessonContent)entityLessonDetails.Adapt(entityLessonDetailsType, lessonContentType)!;
        entityLesson.Adapt(lessonContentModel);
        return lessonContentModel;
    }

    private static LessonDetailsBase MapLessonDetailsEntityFromModel(LessonContent lessonContent)
        => (LessonDetailsBase)lessonContent.Adapt(lessonContent.GetType(), lessonContent.EntityType)!;

    private static Type GetLessonContentTypeByEntity(LessonType entityType)
    {
        return ModelTypesByEntity.GetOrAdd(entityType, entityT =>
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(LessonContent))
                .Where(dtoType =>
                {
                    var constructor = dtoType.GetConstructor(Array.Empty<Type>()) ??
                                      throw new InvalidOperationException();
                    var obj = constructor.Invoke(Array.Empty<object>());
                    var property = dtoType.GetProperty(nameof(LessonContent.LessonType))!;
                    return (LessonType)property.GetValue(obj)! == entityT;
                }).Single();
        });
    }
}
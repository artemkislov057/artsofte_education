using System.Collections.Concurrent;
using System.Reflection;
using Education.Applications.Main.Model.Models.Lessons;
using Education.DataBase.Entities.Lessons;
using Education.DataBase.Extensions;
using Education.DataBase.Repositories;
using Mapster;

namespace Education.Applications.Main.Model.Services;

public interface ILessonsService
{
    Task PostLessons(Guid courseId, Guid moduleId, IEnumerable<LessonContent> lessons);
    Task<LessonContent[]> GetLessons(Guid courseId, Guid moduleId);
}

public class LessonsService : ILessonsService
{
    private readonly ILessonsRepository lessonsRepository;
    private readonly IModulesRepository modulesRepository;
    private static readonly ConcurrentDictionary<Type, Type> ModelTypesByEntity = new();

    public LessonsService(ILessonsRepository lessonsRepository, IModulesRepository modulesRepository)
    {
        this.lessonsRepository = lessonsRepository;
        this.modulesRepository = modulesRepository;
    }

    public async Task PostLessons(Guid courseId, Guid moduleId, IEnumerable<LessonContent> lessons)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            // TODO: кинуть кастомное исключение
            return;
        }

        var entityLessons = lessons.Select(lesson =>
        {
            var entityLessonDetails = GetLessonDetailsEntityFromModel(lesson);
            var entityLesson = new Lesson
                { Name = lesson.Name, Type = entityLessonDetails.GetLessonType(), ModuleId = moduleId };
            entityLesson.SetLessonDetails(entityLessonDetails);
            return entityLesson;
        }).ToArray();

        var lastLessonOrder = await lessonsRepository.FindLastLessonIdInModule(moduleId) ?? -1;
        await lessonsRepository.AddLessons(entityLessons.OrderElements(lastLessonOrder + 1));
    }

    public async Task<LessonContent[]> GetLessons(Guid courseId, Guid moduleId)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            // TODO: кинуть кастомное исключение
            return Array.Empty<LessonContent>();
        }

        var entityLessons = await lessonsRepository.GetLessons(moduleId);
        var models = entityLessons.Select(el =>
        {
            var entityLessonDetails = el.GetLessonDetails();
            var entityLessonDetailsType = entityLessonDetails.GetType();
            var lessonContentType = GetLessonContentTypeByEntity(entityLessonDetailsType);
            var lessonContentModel =
                (LessonContent)entityLessonDetails.Adapt(entityLessonDetailsType, lessonContentType)!;
            lessonContentModel.Id = el.Id;
            lessonContentModel.Name = el.Name;
            return lessonContentModel;
        });
        return models.ToArray();
    }

    private static LessonDetailsBase GetLessonDetailsEntityFromModel(LessonContent lessonContent)
        => (LessonDetailsBase)lessonContent.Adapt(lessonContent.GetType(), lessonContent.EntityType)!;

    private static Type GetLessonContentTypeByEntity(Type entityType)
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
                    var property = dtoType.GetProperty(nameof(LessonContent.EntityType))!;
                    return (Type)property.GetValue(obj)! == entityT;
                }).Single();
        });
    }
}
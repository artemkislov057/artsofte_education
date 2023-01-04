using System.Collections.Concurrent;
using System.Reflection;
using Education.Applications.Main.Model.Exceptions;
using Education.Applications.Main.Model.Extensions;
using Education.Applications.Main.Model.Models.Lessons;
using Education.Applications.Main.Model.Services.EventSender.Events.Lesson;
using Education.Applications.Main.Model.Services.EventSender.Extensions;
using Education.DataBase.Entities.Lessons;
using Education.DataBase.Extensions;
using Education.DataBase.Repositories;
using Mapster;

namespace Education.Applications.Main.Model.Services;

public interface ILessonsService
{
    Task<int[]> PostLessons(Guid courseId, Guid moduleId, LessonContent[] lessons);
    Task<LessonContent[]> GetLessons(Guid courseId, Guid moduleId);
    Task<bool> TryDeleteLesson(Guid courseId, Guid moduleId, int lessonId);
    Task EditLesson(Guid courseId, Guid moduleId, int lessonId, LessonContent lessonModel);
    Task ChangeOrder(Guid courseId, Guid moduleId, int[] orderIds);
}

public class LessonsService : ILessonsService
{
    private readonly ILessonsRepository lessonsRepository;
    private readonly IModulesRepository modulesRepository;
    private readonly ICoursesRepository coursesRepository;
    private readonly IEnumerable<EventSender.EventSender> eventSenders;
    private static readonly ConcurrentDictionary<Type, Type> ModelTypesByEntity = new();

    public LessonsService(ILessonsRepository lessonsRepository,
        IModulesRepository modulesRepository,
        ICoursesRepository coursesRepository,
        IEnumerable<EventSender.EventSender>? eventSenders)
    {
        this.lessonsRepository = lessonsRepository;
        this.modulesRepository = modulesRepository;
        this.coursesRepository = coursesRepository;
        this.eventSenders = eventSenders ?? Enumerable.Empty<EventSender.EventSender>();
    }

    public async Task<int[]> PostLessons(Guid courseId, Guid moduleId, LessonContent[] lessons)
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
        var course = await coursesRepository.FindCourse(courseId, false);
        var module = await modulesRepository.FindModule(moduleId);
        await eventSenders.Send(new LessonAddEvent(course!.Name, module!.Name,
            entityLessons.Select(MapLessonContentFromEntity).ToArray()));
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
        var course = await coursesRepository.FindCourse(courseId, false);
        var module = await modulesRepository.FindModule(moduleId);
        await eventSenders.Send(new LessonDeleteEvent(course!.Name, module!.Name, lesson.Name));
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

        var course = await coursesRepository.FindCourse(courseId, false);
        var module = await modulesRepository.FindModule(moduleId);
        lessonModel.Id = lessonId;
        await eventSenders.Send(new LessonEditEvent(course!.Name, module!.Name, lessonModel));
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
        var course = await coursesRepository.FindCourse(courseId, false);
        var module = await modulesRepository.FindModule(moduleId);
        await eventSenders.Send(new LessonsOrderEditEvent(
            course!.Name,
            module!.Name,
            lessons
                .OrderBy(l => l.Order)
                .Select(l => l.Name)
                .ToArray()
        ));
    }

    public static LessonContent MapLessonContentFromEntity(Lesson entityLesson)
    {
        var entityLessonDetails = entityLesson.GetLessonDetails();
        var entityLessonDetailsType = entityLessonDetails.GetType();
        var lessonContentType = GetLessonContentTypeByEntity(entityLessonDetailsType);
        var lessonContentModel = (LessonContent)entityLessonDetails.Adapt(entityLessonDetailsType, lessonContentType)!;
        entityLesson.Adapt(lessonContentModel);
        return lessonContentModel;
    }

    private static LessonDetailsBase MapLessonDetailsEntityFromModel(LessonContent lessonContent)
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
using Education.Applications.Main.Model.Exceptions;
using Education.Applications.Main.Model.Models.Courses;
using Education.Applications.Main.Model.Services.EventSender;
using Education.Applications.Main.Model.Services.EventSender.Events;
using Education.Applications.Main.Model.Services.EventSender.Events.Course;
using Education.Applications.Main.Model.Services.EventSender.Extensions;
using Education.DataBase.Entities;
using Education.DataBase.Repositories;
using Mapster;

namespace Education.Applications.Main.Model.Services;

public interface ICoursesService
{
    Task<CourseModel> AddCourse(AddOrEditCourseModel course);
    Task<bool> TryDeleteCourse(Guid courseId);
    Task<CourseModel[]> GetCourses();
    Task EditCourse(Guid courseId, AddOrEditCourseModel courseModel);
    Task<CourseModel?> FindCourse(Guid courseId);
}

public class CoursesService : ICoursesService
{
    private readonly ICoursesRepository coursesRepository;
    private readonly IEnumerable<EventSender.EventSender> eventSenders;

    public CoursesService(ICoursesRepository coursesRepository,
        IEnumerable<EventSender.EventSender>? eventSenders = null)
    {
        this.coursesRepository = coursesRepository;
        this.eventSenders = eventSenders ?? Enumerable.Empty<EventSender.EventSender>();
    }

    public async Task<CourseModel> AddCourse(AddOrEditCourseModel course)
    {
        var entityCourse = course.Adapt<Course>();
        await coursesRepository.AddCourse(entityCourse);
        var courseResult = entityCourse.Adapt<CourseModel>();
        await eventSenders.Send(new CourseAddEvent(courseResult));
        return courseResult;
    }

    public async Task<bool> TryDeleteCourse(Guid courseId)
    {
        var course = await coursesRepository.FindCourseById(courseId, false);
        if (course is null)
        {
            return false;
        }

        await coursesRepository.DeleteCourse(course);
        await eventSenders.Send(new CourseDeleteEvent(courseId, course.Name));
        return true;
    }

    public async Task<CourseModel[]> GetCourses()
    {
        var coursesEntity = await coursesRepository.GetCourses();
        return coursesEntity.Adapt<CourseModel[]>();
    }

    public async Task EditCourse(Guid courseId, AddOrEditCourseModel courseModel)
    {
        var courseEntity = await coursesRepository.FindCourseById(courseId);
        if (courseEntity is null)
        {
            throw new NotFoundException("курс", courseId);
        }

        courseModel.Adapt(courseEntity);
        await coursesRepository.EditCourse(courseEntity);
        await eventSenders.Send(new CourseEditEvent(courseModel.Adapt<CourseModel>()));
    }

    public async Task<CourseModel?> FindCourse(Guid courseId)
    {
        var courseEntity = await coursesRepository.FindCourse(courseId);
        if (courseEntity is null)
        {
            return null;
        }

        var model = courseEntity.Adapt<CourseModel>();
        var modulesEntityArray = courseEntity.Modules!.ToArray();
        for (var i = 0; i < modulesEntityArray.Length; i++)
        {
            var moduleModel = model.Modules[i];
            var moduleEntity = modulesEntityArray[i];
            moduleModel.Lessons = moduleEntity.Lessons!.Select(LessonsService.MapLessonContentFromEntity).ToArray();
        }

        return model;
    }
}
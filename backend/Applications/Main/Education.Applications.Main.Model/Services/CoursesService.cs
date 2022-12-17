using Education.Applications.Main.Model.Models.Courses;
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

    public CoursesService(ICoursesRepository coursesRepository)
    {
        this.coursesRepository = coursesRepository;
    }

    public async Task<CourseModel> AddCourse(AddOrEditCourseModel course)
    {
        var entityCourse = course.Adapt<Course>();
        await coursesRepository.AddCourse(entityCourse);
        return entityCourse.Adapt<CourseModel>();
    }

    public async Task<bool> TryDeleteCourse(Guid courseId)
    {
        var course = await coursesRepository.FindCourseById(courseId, false);
        if (course is null)
        {
            return false;
        }

        await coursesRepository.DeleteCourse(course);
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
            // TODO: кинуть исключение
            return;
        }

        courseModel.Adapt(courseEntity);
        await coursesRepository.EditCourse(courseEntity);
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
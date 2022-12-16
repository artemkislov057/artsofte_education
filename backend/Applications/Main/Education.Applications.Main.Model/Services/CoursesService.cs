using Education.DataBase.Entities;
using Education.DataBase.Repositories;

namespace Education.Applications.Main.Model.Services;

public interface ICoursesService
{
    Task AddCourse(Course course);
    Task<bool> TryDeleteCourse(Guid courseId);
    Task<Course[]> GetCourses();
}

public class CoursesService : ICoursesService
{
    private readonly ICoursesRepository coursesRepository;

    public CoursesService(ICoursesRepository coursesRepository)
    {
        this.coursesRepository = coursesRepository;
    }

    public async Task AddCourse(Course course)
        => await coursesRepository.AddCourse(course);

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

    public async Task<Course[]> GetCourses()
        => await coursesRepository.GetCourses();
}
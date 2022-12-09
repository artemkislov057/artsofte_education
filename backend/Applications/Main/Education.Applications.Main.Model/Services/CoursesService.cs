using Education.DataBase.Entities;
using Education.DataBase.Repositories;

namespace Education.Applications.Main.Model.Services;

public interface ICoursesService
{
    Task AddCourse(Course course);
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

    public async Task<Course[]> GetCourses()
        => await coursesRepository.GetCourses();
}
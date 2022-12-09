using Education.DataBase;
using Education.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.Applications.Main.Model.Services;

public interface ICoursesService
{
    Task AddCourse(Course course);
    Task<Course[]> GetCourses();
}

public class CoursesService : ICoursesService
{
    private readonly EducationDbContext context;

    public CoursesService(EducationDbContext context)
    {
        this.context = context;
    }

    public async Task AddCourse(Course course)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync();
    }

    public async Task<Course[]> GetCourses()
        => await context.Courses
            .Include(c => c.Chapters)
            .ToArrayAsync();
}
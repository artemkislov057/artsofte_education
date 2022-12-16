using Education.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface ICoursesRepository
{
    Task AddCourse(Course course);
    Task DeleteCourse(Course course);
    Task<Course[]> GetCourses(bool includeModules = true);
    Task<Course?> FindCourseById(Guid courseId, bool includeModules = true);
}

public class CoursesRepository : ICoursesRepository
{
    private readonly EducationDbContext context;

    public CoursesRepository(EducationDbContext context)
    {
        this.context = context;
    }

    public async Task AddCourse(Course course)
    {
        context.Courses.Add(course);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCourse(Course course)
    {
        context.Courses.Remove(course);
        await context.SaveChangesAsync();
    }

    public async Task<Course[]> GetCourses(bool includeModules = true)
        => await GetCoursesQuery(includeModules)
            .ToArrayAsync();

    public async Task<Course?> FindCourseById(Guid courseId, bool includeModules = true)
        => await GetCoursesQuery(includeModules)
            .SingleOrDefaultAsync(c => c.Id == courseId);

    private IQueryable<Course> GetCoursesQuery(bool includeModules)
    {
        var query = context.Courses.AsQueryable();
        return includeModules
            ? query.Include(c => c.Modules!.OrderBy(ch => ch.Order))
            : query;
    }
}
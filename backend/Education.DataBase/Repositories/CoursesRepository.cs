using Education.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface ICoursesRepository
{
    Task AddCourse(Course course);
    Task<Course[]> GetCourses(bool includeChapters = true);
    Task<Course?> FindCourseById(Guid courseId, bool includeChapters = true);
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

    public async Task<Course[]> GetCourses(bool includeChapters = true)
        => await GetCoursesQuery(includeChapters)
            .ToArrayAsync();

    public async Task<Course?> FindCourseById(Guid courseId, bool includeChapters = true)
        => await GetCoursesQuery(includeChapters)
            .SingleOrDefaultAsync(c => c.Id == courseId);

    private IQueryable<Course> GetCoursesQuery(bool includeChapters)
    {
        var query = context.Courses.AsQueryable();
        return includeChapters
            ? query.Include(c => c.Chapters!.OrderBy(ch => ch.Order))
            : query;
    }
}
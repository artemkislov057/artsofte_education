using Education.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface ICoursesRepository
{
    Task AddCourse(Course course);
    Task<Course[]> GetCourses();
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

    public async Task<Course[]> GetCourses() =>
        await context.Courses
            .Include(c => c.Chapters!.OrderBy(ch => ch.Order))
            .ToArrayAsync();

    public async Task<Course?> FindCourseById(Guid courseId, bool includeChapters)
    {
        var query = context.Courses.AsQueryable();
        if (includeChapters)
        {
            query = query.Include(c => c.Chapters!.OrderBy(ch => ch.Order));
        }

        return await query.SingleOrDefaultAsync(c => c.Id == courseId);
    }
}
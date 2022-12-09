using Education.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IChaptersRepository
{
    Task AddChapterToCourse(Chapter chapter, Course course);
    Task<int?> GetLastOrderByCourseId(Guid courseId);
}

public class ChaptersRepository : IChaptersRepository
{
    private readonly EducationDbContext context;

    public ChaptersRepository(EducationDbContext context)
    {
        this.context = context;
    }

    public async Task AddChapterToCourse(Chapter chapter, Course course)
    {
        chapter.CourseId = course.Id;
        context.Chapters.Add(chapter);
        await context.SaveChangesAsync();
    }

    public async Task<int?> GetLastOrderByCourseId(Guid courseId)
    {
        var orders = await context.Chapters
            .Where(ch => ch.CourseId == courseId)
            .Select(ch => ch.Order)
            .ToArrayAsync();
        return orders.Length > 0 ? orders.Max() : -1;
    }
}
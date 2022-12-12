using Education.DataBase.Entities;
using Education.DataBase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IChaptersRepository
{
    Task AddChapterToCourse(Chapter chapter, Course course);
    Task<int?> FindLastOrderByCourseId(Guid courseId);
    Task<bool> IsExistsChapterByIdAndCourseId(Guid chapterId, Guid courseId);
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

    public async Task<int?> FindLastOrderByCourseId(Guid courseId)
    {
        return await context.Chapters
            .Where(ch => ch.CourseId == courseId)
            .GetMaxOrder();
    }

    public async Task<bool> IsExistsChapterByIdAndCourseId(Guid chapterId, Guid courseId) =>
        await context.Chapters.AnyAsync(ch => ch.Id == chapterId && ch.CourseId == courseId);
}
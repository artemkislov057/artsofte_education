using Education.DataBase.Entities.Lessons;
using Education.DataBase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface ILessonsRepository
{
    Task AddLessons(IEnumerable<Lesson> lessons);
    Task<Lesson[]> GetLessons(Guid moduleId);
    Task<int?> FindLastLessonIdInModule(Guid moduleId);
}

public class LessonsRepository : ILessonsRepository
{
    private readonly EducationDbContext context;

    public LessonsRepository(EducationDbContext context)
        => this.context = context;

    public async Task AddLessons(IEnumerable<Lesson> lessons)
    {
        context.AddRange(lessons);
        await context.SaveChangesAsync();
    }

    public async Task<Lesson[]> GetLessons(Guid moduleId)
    {
        return await context.Lessons
            .Where(w => w.ModuleId == moduleId)
            .OrderBy(w => w.Order)
            .IncludeLessonDetails()
            .ToArrayAsync();
    }

    public async Task<int?> FindLastLessonIdInModule(Guid moduleId)
    {
        return await context.Lessons
            .Where(w => w.ModuleId == moduleId)
            .GetMaxOrder();
    }
}
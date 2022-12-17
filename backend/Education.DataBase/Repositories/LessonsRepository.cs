using Education.DataBase.Entities.Lessons;
using Education.DataBase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface ILessonsRepository
{
    Task AddLessons(IEnumerable<Lesson> lessons);
    Task<Lesson[]> GetLessons(Guid moduleId, bool includeDetails = true);
    Task<Lesson?> FindLesson(int lessonId, bool includeDetails = true);
    Task<int?> FindLastLessonIdInModule(Guid moduleId);
    Task DeleteLesson(Lesson lesson);
    Task ChangeLessonDetails(Lesson lesson, LessonDetailsBase oldLessonDetails, LessonDetailsBase newLessonDetails);
    Task EditLessonDetails(LessonDetailsBase lessonDetails);
    Task EditLessons(Lesson[] lessons);
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

    public async Task<Lesson[]> GetLessons(Guid moduleId, bool includeDetails = true)
    {
        var query = context.Lessons
            .Where(w => w.ModuleId == moduleId)
            .OrderBy(w => w.Order)
            .AsQueryable();

        if (includeDetails)
        {
            query = query.IncludeLessonDetails();
        }

        return await query.ToArrayAsync();
    }

    public async Task<Lesson?> FindLesson(int lessonId, bool includeDetails = true)
    {
        var query = context.Lessons.AsQueryable();

        if (includeDetails)
        {
            query = query.IncludeLessonDetails();
        }

        return await query.SingleOrDefaultAsync(l => l.Id == lessonId);
    }

    public async Task<int?> FindLastLessonIdInModule(Guid moduleId)
    {
        return await context.Lessons
            .Where(w => w.ModuleId == moduleId)
            .GetMaxOrder();
    }

    public async Task DeleteLesson(Lesson lesson)
    {
        context.Lessons.Remove(lesson);
        await context.SaveChangesAsync();
    }

    public async Task ChangeLessonDetails(Lesson lesson, LessonDetailsBase oldLessonDetails,
        LessonDetailsBase newLessonDetails)
    {
        if (oldLessonDetails.LessonId != lesson.Id)
        {
            // TODO: кинуть кастомное исключение
            return;
        }

        newLessonDetails.LessonId = lesson.Id;
        context.Remove(oldLessonDetails);
        context.Add(newLessonDetails);
        await context.SaveChangesAsync();
    }

    public async Task EditLessonDetails(LessonDetailsBase lessonDetails)
    {
        await context.SaveChangesAsync();
    }

    public async Task EditLessons(Lesson[] lessons)
    {
        await context.SaveChangesAsync();
    }
}
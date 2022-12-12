using Education.DataBase.Entities;
using Education.DataBase.Repositories;

namespace Education.Applications.Main.Model.Services;

public interface IChaptersService
{
    Task AddChapterToCourse(Guid courseId, Chapter chapter);
}

public class ChaptersService : IChaptersService
{
    private readonly ICoursesRepository coursesRepository;
    private readonly IChaptersRepository chaptersRepository;

    public ChaptersService(ICoursesRepository coursesRepository, IChaptersRepository chaptersRepository)
    {
        this.coursesRepository = coursesRepository;
        this.chaptersRepository = chaptersRepository;
    }

    public async Task AddChapterToCourse(Guid courseId, Chapter chapter)
    {
        var course = await coursesRepository.FindCourseById(courseId);
        if (course is null)
        {
            // TODO: кинуть кастомное исключение
            return;
        }

        var lastOrder = await chaptersRepository.FindLastOrderByCourseId(courseId) ?? -1;
        chapter.Order = lastOrder + 1;
        await chaptersRepository.AddChapterToCourse(chapter, course);
    }
}
using Education.DataBase.Enums.Lessons;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Lessons;

public class Lesson : IOrderEntity<int>
{
    public int Id { get; set; }
    public int Order { get; set; }
    public LessonType Type { get; set; }
    public string Name { get; set; } = null!;

    public Guid ModuleId { get; set; }
    public Module? Module { get; set; }

    public VideoLesson? VideoLesson { get; set; }
    public PresentationLesson? PresentationLesson { get; set; }
    public LiteratureLesson? LiteratureLesson { get; set; }
    public TextLesson? TextLesson { get; set; }
}
using Education.DataBase.Enums.Lessons;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Lessons;

public class Lesson : IOrderElement
{
    public int Id { get; set; }
    public int Order { get; set; }
    public LessonType Type { get; set; }

    public Guid ModuleId { get; set; }
    public Module? Module { get; set; }

    public VideoLesson? VideoLesson { get; set; }
    public PresentationLesson? PresentationLesson { get; set; }
    public LiteratureLesson? LiteratureLesson { get; set; }
}
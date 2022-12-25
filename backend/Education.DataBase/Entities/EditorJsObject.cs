using Education.DataBase.Entities.Lessons;
using Education.DataBase.Entities.Lessons.LessonContent;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities;

public class EditorJsObject : IEntity<int>
{
    public int Id { get; set; }
    public long Time { get; set; }
    public ICollection<TextBlock> Blocks { get; set; } = null!;
    public string Version { get; set; } = null!;

    public TextLesson? TextLesson { get; set; }
    public Lesson? Lesson { get; set; }
}
using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Text;

public class TextLessonModel : LessonContent
{
    public long Time { get; set; }
    public TextBlockModel[] Blocks { get; set; } = null!;
    public string Version { get; set; } = null!;

    public override Type EntityType => typeof(TextLesson);
}
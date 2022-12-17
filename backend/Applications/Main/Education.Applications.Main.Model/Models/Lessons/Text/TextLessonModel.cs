using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Text;

public class TextLessonModel : LessonContent
{
    public string Value { get; set; } = null!;
    public override Type EntityType => typeof(TextLesson);
}
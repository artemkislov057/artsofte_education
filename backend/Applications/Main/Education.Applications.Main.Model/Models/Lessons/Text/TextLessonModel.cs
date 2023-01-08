using Education.Applications.Main.Model.Models.EditorJs;
using Education.DataBase.Entities.Lessons;
using Education.DataBase.Enums.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Text;

public class TextLessonModel : LessonContent
{
    public EditorJsObjectModel Value { get; set; } = null!;
    public override Type EntityType => typeof(TextLesson);
    public override LessonType LessonType => LessonType.Text;
}
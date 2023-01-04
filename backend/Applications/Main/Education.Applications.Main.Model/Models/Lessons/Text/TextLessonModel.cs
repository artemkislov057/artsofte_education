using Education.Applications.Main.Model.Models.EditorJs;
using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Text;

public class TextLessonModel : LessonContent
{
    public EditorJsObjectModel Value { get; set; } = null!;
    public override string GetLessonDisplayType => "Текст";
    public override Type EntityType => typeof(TextLesson);
}
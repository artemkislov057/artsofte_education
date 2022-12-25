using System.ComponentModel.DataAnnotations.Schema;
using Education.DataBase.Enums.Lessons;

namespace Education.DataBase.Entities.Lessons;

public class TextLesson : LessonDetailsBase
{
    public int EditorJsObjectId { get; set; }
    [ForeignKey(nameof(EditorJsObjectId))] public EditorJsObject Value { get; set; }

    public override LessonType GetLessonType()
    {
        return LessonType.Text;
    }
}
using Education.DataBase.Enums.Lessons;

namespace Education.DataBase.Entities.Lessons;

public class TextLesson : LessonDetailsBase
{
    public string Value { get; set; } = null!;

    public override LessonType GetLessonType()
    {
        return LessonType.Text;
    }
}
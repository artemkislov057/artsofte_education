using Education.DataBase.Entities.Lessons.LessonContent;
using Education.DataBase.Enums.Lessons;

namespace Education.DataBase.Entities.Lessons;

public class TestLesson : LessonDetailsBase
{
    public ICollection<TestQuestion> Questions { get; set; } = null!;

    public override LessonType GetLessonType()
    {
        return LessonType.Test;
    }
}
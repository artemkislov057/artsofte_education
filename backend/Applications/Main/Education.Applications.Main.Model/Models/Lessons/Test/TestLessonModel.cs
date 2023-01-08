using Education.DataBase.Entities.Lessons;
using Education.DataBase.Enums.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Test;

public class TestLessonModel : LessonContent
{
    public TestQuestionModel[] Questions { get; set; } = null!;
    public override Type EntityType => typeof(TestLesson);
    public override LessonType LessonType => LessonType.Test;
}
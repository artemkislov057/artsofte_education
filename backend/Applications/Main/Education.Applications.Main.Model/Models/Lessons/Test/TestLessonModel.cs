using System.ComponentModel.DataAnnotations;
using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Test;

public class TestLessonModel : LessonContent
{
    [Display(Name = "Вопросы")] public TestQuestionModel[] Questions { get; set; } = null!;
    public override string GetLessonDisplayType => "Тест";
    public override Type EntityType => typeof(TestLesson);
}
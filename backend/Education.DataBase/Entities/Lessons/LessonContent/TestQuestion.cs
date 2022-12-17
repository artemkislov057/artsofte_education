using System.ComponentModel.DataAnnotations.Schema;
using Education.DataBase.Enums.Lessons.Test;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Lessons.LessonContent;

public class TestQuestion : IOrderEntity<int>
{
    public int Id { get; set; }
    public int Order { get; set; }

    public string Question { get; set; } = null!;
    public QuestionType QuestionType { get; set; }
    public ICollection<QuestionAnswerOption> AnswerOptions { get; set; } = null!;

    public int TestId { get; set; }
    [ForeignKey(nameof(TestId))] public TestLesson TestLesson { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations.Schema;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Lessons.LessonContent;

public class QuestionAnswerOption : IOrderEntity<int>
{
    public int Id { get; set; }
    public int Order { get; set; }

    public string Value { get; set; } = null!;
    public bool IsCorrectAnswer { get; set; }

    public int QuestionId { get; set; }
    [ForeignKey(nameof(QuestionId))] public TestQuestion TestQuestion { get; set; } = null!;
}
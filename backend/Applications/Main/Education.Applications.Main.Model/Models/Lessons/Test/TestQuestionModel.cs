namespace Education.Applications.Main.Model.Models.Lessons.Test;

public class TestQuestionModel
{
    public string Question { get; set; } = null!;
    public QuestionTypeModel QuestionType { get; set; }
    public QuestionAnswerOptionModel[] AnswerOptions { get; set; } = null!;
}
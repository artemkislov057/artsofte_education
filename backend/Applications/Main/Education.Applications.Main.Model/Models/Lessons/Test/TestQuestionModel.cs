namespace Education.Applications.Main.Model.Models.Lessons.Test;

public class TestQuestionModel : IDisplayValue
{
    public string Question { get; set; } = null!;
    public QuestionTypeModel QuestionType { get; set; }
    public QuestionAnswerOptionModel[] AnswerOptions { get; set; } = null!;

    public string GetDisplaySting()
    {
        return Question;
    }
}
﻿using Education.Applications.Main.Model.Models.EditorJs;

namespace Education.Applications.Main.Model.Models.Lessons.Test;

public class TestQuestionModel
{
    public EditorJsObjectModel Question { get; set; } = null!;
    public QuestionTypeModel QuestionType { get; set; }
    public QuestionAnswerOptionModel[] AnswerOptions { get; set; } = null!;
}
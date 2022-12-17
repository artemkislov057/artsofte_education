namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Test;

public record TestQuestionDto(string Question, QuestionTypeDto QuestionType, QuestionAnswerOptionDto[] AnswerOptions);
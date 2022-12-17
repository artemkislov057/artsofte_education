namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Test;

/// <summary>
/// Модель вопроса
/// </summary>
/// <param name="Question">Текст вопроса</param>
/// <param name="QuestionType">Тип вопроса (количество правильных ответов)</param>
/// <param name="AnswerOptions">Варианты ответа</param>
public record TestQuestionDto(string Question, QuestionTypeDto QuestionType, QuestionAnswerOptionDto[] AnswerOptions);
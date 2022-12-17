namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Test;

/// <summary>
/// Модель варианта ответа
/// </summary>
/// <param name="Value">Текст ответа</param>
/// <param name="IsCorrectAnswer">Правильный ли ответ</param>
public record QuestionAnswerOptionDto(string Value, bool IsCorrectAnswer);
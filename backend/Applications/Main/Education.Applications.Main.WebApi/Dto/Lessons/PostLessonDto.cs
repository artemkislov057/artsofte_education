using System.Text.Json;

namespace Education.Applications.Main.WebApi.Dto.Lessons;

/// <summary>
/// Модель добавления урока
/// </summary>
/// <param name="Name">Название урока</param>
/// <param name="Type">DTO, определяющее тип поля value</param>
/// <param name="Value">Контент урока</param>
public record PostLessonDto(string Name, LessonTypeDto Type, JsonElement Value);
using Education.Applications.Main.WebApi.Dto.EditorJs;

namespace Education.Applications.Main.WebApi.Dto.Lessons;

/// <summary>
/// Модель урока
/// </summary>
/// <param name="Id">Идентификатор урока</param>
/// <param name="Name">Название урока</param>
/// <param name="Type">DTO, определяющее тип поля value</param>
/// <param name="Value">Контент урока</param>
public record GetLessonDto(int Id, string Name, LessonTypeDto Type, object Value, EditorJsDto? AdditionalText);
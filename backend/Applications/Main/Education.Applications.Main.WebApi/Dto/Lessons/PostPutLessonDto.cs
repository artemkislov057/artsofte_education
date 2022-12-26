using System.ComponentModel.DataAnnotations;
using Education.Applications.Main.WebApi.Dto.EditorJs;

namespace Education.Applications.Main.WebApi.Dto.Lessons;

/// <summary>
/// Модель добавления урока
/// </summary>
/// <param name="Name">Название урока</param>
/// <param name="Type">DTO, определяющее тип поля value</param>
/// <param name="Value">Контент урока</param>
public record PostPutLessonDto(
    string Name,
    [Required] LessonTypeDto? Type,
    [Required] object Value,
    EditorJsDto? AdditionalText
);
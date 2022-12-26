using System.ComponentModel.DataAnnotations;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Literature;

/// <summary>
/// Модель книги из списка литературы
/// </summary>
/// <param name="Name">Название книги</param>
/// <param name="Description">Описание книги</param>
/// <param name="CoverSrc">Ссылка на изображение обложки</param>
/// <param name="PurchaseLinks">Массив ссылок на покупку книги</param>
public record LiteratureElementDto(
    string Name,
    string? Description,
    string? CoverSrc,
    string[] PurchaseLinks
);
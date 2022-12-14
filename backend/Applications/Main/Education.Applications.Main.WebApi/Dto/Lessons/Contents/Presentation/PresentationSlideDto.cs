namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Presentation;

/// <summary>
/// Модель слайда презентации
/// </summary>
/// <param name="ImageSrc">Ссылка на изображение</param>
/// <param name="Description">Описание слайда</param>
/// <param name="VoiceSrc">Ссылка на голосовое сопровождение</param>
public record PresentationSlideDto(string ImageSrc, string Description, string VoiceSrc);
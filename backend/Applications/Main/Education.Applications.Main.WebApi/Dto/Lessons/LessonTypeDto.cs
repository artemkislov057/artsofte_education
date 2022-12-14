namespace Education.Applications.Main.WebApi.Dto.Lessons;

/// <summary>
/// Тип урока
/// </summary>
public enum LessonTypeDto
{
    /// <summary>
    /// Видео
    /// </summary>
    Video = 0,

    /// <summary>
    /// Презентация
    /// </summary>
    Presentation = 1,

    /// <summary>
    /// Текст
    /// </summary>
    Text = 2,

    /// <summary>
    /// Список литературы
    /// </summary>
    Literature = 3
}
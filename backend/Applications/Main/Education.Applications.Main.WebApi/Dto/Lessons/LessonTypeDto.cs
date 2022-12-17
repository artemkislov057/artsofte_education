namespace Education.Applications.Main.WebApi.Dto.Lessons;

/// <summary>
/// Тип урока
/// </summary>
public enum LessonTypeDto
{
    /// <summary>
    /// Видео
    /// </summary>
    Video = 1,

    /// <summary>
    /// Презентация
    /// </summary>
    Presentation = 2,

    /// <summary>
    /// Список литературы
    /// </summary>
    Literature = 3,

    /// <summary>
    /// Текст
    /// </summary>
    Text = 4,

    /// <summary>
    /// Тест
    /// </summary>
    Test = 5
}
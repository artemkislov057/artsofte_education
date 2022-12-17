using Education.Applications.Main.WebApi.Dto.Lessons;

namespace Education.Applications.Main.WebApi.Dto.Modules;

/// <summary>
/// Модель модуля
/// </summary>
public class ModuleDto
{
    /// <summary>
    /// Идентификатор модуля
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Название модуля
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание модуля
    /// </summary>
    public string Description { get; init; }

    public GetLessonDto[]? Lessons { get; set; }
}
namespace Education.Applications.Main.WebApi.Dto.Modules;

/// <summary>
/// Модель добавления модуля
/// </summary>
/// <param name="Name">Название модуля</param>
/// <param name="Description">Описание модуля</param>
public record PostModuleDto(string Name, string? Description);
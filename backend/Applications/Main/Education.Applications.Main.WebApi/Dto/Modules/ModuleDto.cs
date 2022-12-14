namespace Education.Applications.Main.WebApi.Dto.Modules;

/// <summary>
/// Модель модуля
/// </summary>
/// <param name="Id">Идентификатор модуля</param>
/// <param name="Name">Название модуля</param>
/// <param name="Description">Описание модуля</param>
public record ModuleDto(Guid Id, string Name, string Description);
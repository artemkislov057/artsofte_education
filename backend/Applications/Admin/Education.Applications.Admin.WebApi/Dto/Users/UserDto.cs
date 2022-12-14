namespace Education.Applications.Admin.WebApi.Dto.Users;

/// <summary>
/// Модель пользователя
/// </summary>
/// <param name="Id">Идентификатор пользователя</param>
/// <param name="Name">Имя пользователя</param>
public record UserDto(Guid Id, string Name);
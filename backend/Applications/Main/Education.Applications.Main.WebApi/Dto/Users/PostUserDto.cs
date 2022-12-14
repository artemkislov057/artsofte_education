namespace Education.Applications.Main.WebApi.Dto.Users;

/// <summary>
/// Модель регистрации пользователя
/// </summary>
/// <param name="Name">Имя пользователя</param>
/// <param name="Password">Пароль</param>
/// <param name="IsPersistent">Флаг, обозначающий, нужно ли сохранять аутентификацию в системе</param>
public record PostUserDto(string Name, string Password, bool IsPersistent = false);
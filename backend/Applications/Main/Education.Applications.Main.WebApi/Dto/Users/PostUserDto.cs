namespace Education.Applications.Main.WebApi.Dto.Users;

public record PostUserDto(string Name, string Password, bool IsPersistent = false);
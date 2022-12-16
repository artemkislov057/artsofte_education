namespace Education.Applications.Main.WebApi.Dto.Courses;

/// <summary>
/// Модель добавления курса
/// </summary>
/// <param name="Name">Название курса</param>
/// <param name="Description">Описание</param>
public record PostPutCourseDto(string Name, string? Description);
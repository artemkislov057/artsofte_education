using Education.Applications.Main.WebApi.Dto.Modules;

namespace Education.Applications.Main.WebApi.Dto.Courses;

/// <summary>
/// Модель курса
/// </summary>
/// <param name="Id">Идентификатор курса</param>
/// <param name="Name">Название курса</param>
/// <param name="Description">Описание курса</param>
/// <param name="Modules">Модули</param>
public record CourseDto(Guid Id, string Name, string Description, ModuleDto[] Modules);
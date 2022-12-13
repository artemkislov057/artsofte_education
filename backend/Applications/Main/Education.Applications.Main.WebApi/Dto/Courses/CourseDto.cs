using Education.Applications.Main.WebApi.Dto.Modules;

namespace Education.Applications.Main.WebApi.Dto.Courses;

public record CourseDto(Guid Id, string Name, string Description, ModuleDto[] Modules);
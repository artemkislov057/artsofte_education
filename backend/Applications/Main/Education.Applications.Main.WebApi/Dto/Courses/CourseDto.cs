namespace Education.Applications.Main.WebApi.Dto.Courses;

public record CourseDto(Guid Id, string Name, string Description, object[] Chapters);
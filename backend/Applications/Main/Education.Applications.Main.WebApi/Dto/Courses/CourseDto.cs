using Education.Applications.Main.WebApi.Dto.Chapters;

namespace Education.Applications.Main.WebApi.Dto.Courses;

public record CourseDto(Guid Id, string Name, string Description, ChapterDto[] Chapters);
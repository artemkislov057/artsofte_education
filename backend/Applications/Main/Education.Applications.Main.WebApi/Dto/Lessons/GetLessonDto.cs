namespace Education.Applications.Main.WebApi.Dto.Lessons;

public record GetLessonDto(int Id, string Name, LessonTypeDto Type, object Value);
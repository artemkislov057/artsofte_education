namespace Education.Applications.Main.WebApi.Dto.Lessons;

public record GetLessonDto(int Id, LessonTypeDto Type, object Value);
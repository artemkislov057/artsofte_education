using System.Text.Json;

namespace Education.Applications.Main.WebApi.Dto.Lessons;

public record PostLessonDto(string Name, LessonTypeDto Type, JsonElement Value);
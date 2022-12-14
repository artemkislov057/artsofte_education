using System.Text.Json;

namespace Education.Applications.Main.WebApi.Dto.Lessons;

public record PostLessonDto(LessonTypeDto Type, JsonElement Value);
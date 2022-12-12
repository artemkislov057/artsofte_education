using System.Text.Json;

namespace Education.Applications.Main.WebApi.Dto.Widgets;

public record PostWidgetDto(WidgetTypeDto Type, JsonElement Value);
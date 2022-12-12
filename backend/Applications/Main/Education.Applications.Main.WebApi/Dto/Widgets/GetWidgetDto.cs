namespace Education.Applications.Main.WebApi.Dto.Widgets;

public record GetWidgetDto(int Id, WidgetTypeDto Type, object Value);
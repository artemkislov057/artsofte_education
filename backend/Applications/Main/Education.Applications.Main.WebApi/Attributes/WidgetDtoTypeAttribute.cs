using Education.Applications.Main.WebApi.Dto.Widgets;

namespace Education.Applications.Main.WebApi.Attributes;

public class WidgetDtoTypeAttribute : Attribute
{
    public WidgetTypeDto WidgetType { get; }

    public WidgetDtoTypeAttribute(WidgetTypeDto widgetType)
    {
        WidgetType = widgetType;
    }
}
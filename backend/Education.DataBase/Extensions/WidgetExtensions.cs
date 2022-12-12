using Education.DataBase.Entities.Widgets;

namespace Education.DataBase.Extensions;

public static class WidgetExtensions
{
    public static void SetWidgetDetails(this Widget source, WidgetDetailsBase details)
    {
        source.GetType()
            .GetProperties()
            .Single(p => p.PropertyType == details.GetType())
            .SetValue(source, details);
    }
}
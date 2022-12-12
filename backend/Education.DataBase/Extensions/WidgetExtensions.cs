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

    public static WidgetDetailsBase GetWidgetDetails(this Widget source) =>
        source.GetType()
            .GetProperties()
            .Where(p => p.PropertyType.BaseType == typeof(WidgetDetailsBase))
            .Select(p => (WidgetDetailsBase?)p.GetValue(source))
            .Single(d => d != null)!;
}
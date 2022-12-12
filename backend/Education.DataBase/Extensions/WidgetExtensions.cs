using Education.DataBase.Entities.Widgets;
using Microsoft.EntityFrameworkCore;

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

    public static IQueryable<Widget> IncludeWidgetDetails(this IQueryable<Widget> source) =>
        typeof(Widget).GetProperties()
            .Where(p => p.PropertyType.BaseType == typeof(WidgetDetailsBase))
            .Aggregate(source, (current, widgetDetailsProperty) => current.Include(widgetDetailsProperty.Name));
}
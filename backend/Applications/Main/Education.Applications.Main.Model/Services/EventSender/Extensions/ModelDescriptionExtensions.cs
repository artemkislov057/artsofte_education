using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Education.Applications.Main.Model.Models;

namespace Education.Applications.Main.Model.Services.EventSender.Extensions;

public static class ModelDescriptionExtensions
{
    public static string[] GetDisplayAttributeNames(this object source) =>
        source.GetType()
            .GetProperties()
            .Select(p => new KeyValuePair<PropertyInfo, DisplayAttribute?>(p, p.GetCustomAttribute<DisplayAttribute>()))
            .Where(p => p.Value != null && p.Key.GetValue(source) != null)
            .Select(p => $"{p.Value?.Name ?? p.Key.Name}: {p.Key.GetValue(source)!.GetDisplayText()}")
            .ToArray();

    public static string GetModelDescription(this object source) =>
        string.Join('\n', source.GetDisplayAttributeNames());

    public static string GetDisplayText(this object source) =>
        source switch
        {
            string text => text,
            IEnumerable enumerable => "\n" + string.Join('\n', from object e in enumerable select "*    " + GetDisplayText(e) + ";"),
            IDisplayValue displayValue => displayValue.GetDisplaySting(),
            _ => source.ToString() ?? string.Empty
        };
}
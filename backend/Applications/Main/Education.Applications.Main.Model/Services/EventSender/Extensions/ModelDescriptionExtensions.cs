using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Education.Applications.Main.Model.Services.EventSender.Extensions;

public static class ModelDescriptionExtensions
{
    public static string[] GetDisplayAttributeNames(this object source) =>
        source.GetType()
            .GetProperties()
            .Select(p => new KeyValuePair<PropertyInfo, DisplayAttribute?>(p, p.GetCustomAttribute<DisplayAttribute>()))
            .Where(p => p.Value != null)
            .Select(p => $"{p.Value?.Name ?? p.Key.Name}: {p.Key.GetValue(source)}")
            .ToArray();

    public static string GetModelDescription(this object source) =>
        string.Join('\n', source.GetDisplayAttributeNames());
}
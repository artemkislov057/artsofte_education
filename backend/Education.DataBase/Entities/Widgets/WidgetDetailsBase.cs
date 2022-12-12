using System.ComponentModel.DataAnnotations;
using Education.DataBase.Enums.Widgets;

namespace Education.DataBase.Entities.Widgets;

public abstract class WidgetDetailsBase
{
    [Key] public int WidgetId { get; set; }
    public Widget Widget { get; set; } = null!;

    public abstract WidgetType GetWidgetType();
}
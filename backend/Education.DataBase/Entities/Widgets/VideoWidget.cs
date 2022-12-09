using System.ComponentModel.DataAnnotations;
using Education.DataBase.Enums.Widgets;

namespace Education.DataBase.Entities.Widgets;

public class VideoWidget
{
    [Key] public int WidgetId { get; set; }
    public Widget Widget { get; set; } = null!;

    public VideoType VideoType { get; set; }
    public string Src { get; set; } = null!;
}
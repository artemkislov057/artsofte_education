using System.ComponentModel.DataAnnotations;
using Education.DataBase.Entities.Widgets.WidgetContent;

namespace Education.DataBase.Entities.Widgets;

public class PresentationWidget
{
    [Key] public int WidgetId { get; set; }
    public Widget Widget { get; set; } = null!;

    public ICollection<PresentationSlide>? PresentationSlides { get; set; }
}
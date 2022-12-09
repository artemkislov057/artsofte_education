using System.ComponentModel.DataAnnotations;
using Education.DataBase.Entities.Widgets.WidgetContent;

namespace Education.DataBase.Entities.Widgets;

public class LiteratureWidget
{
    [Key] public int WidgetId { get; set; }
    public Widget Widget { get; set; } = null!;

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string CoverSrc { get; set; } = null!;

    public ICollection<LiteraturePurchaseLink>? LiteraturePurchaseLinks { get; set; }
}
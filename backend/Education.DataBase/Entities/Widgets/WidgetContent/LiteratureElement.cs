using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Widgets.WidgetContent;

public class LiteratureElement : IOrderElement
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CoverSrc { get; set; }

    public int LiteratureWidgetId { get; set; }
    public LiteratureWidget LiteratureWidget { get; set; } = null!;

    public ICollection<LiteraturePurchaseLink> PurchaseLinks { get; set; } = null!;
}
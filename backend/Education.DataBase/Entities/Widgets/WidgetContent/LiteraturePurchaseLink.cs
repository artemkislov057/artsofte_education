using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Widgets.WidgetContent;

public class LiteraturePurchaseLink : IOrderElement
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string Value { get; set; } = null!;

    public int LiteratureElementId { get; set; }
    public LiteratureElement LiteratureElement { get; set; } = null!;
}
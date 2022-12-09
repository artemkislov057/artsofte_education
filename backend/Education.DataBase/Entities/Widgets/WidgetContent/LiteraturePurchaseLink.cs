using System.ComponentModel.DataAnnotations.Schema;

namespace Education.DataBase.Entities.Widgets.WidgetContent;

public class LiteraturePurchaseLink
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string Value { get; set; } = null!;

    public int? LiteratureId { get; set; }
    [ForeignKey(nameof(LiteratureId))] public LiteratureWidget? LiteratureWidget { get; set; }
}
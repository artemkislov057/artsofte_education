using Education.DataBase.Entities.Widgets;

namespace Education.Applications.Main.Model.Models.Widgets.Literature;

public class LiteratureWidgetModel : WidgetContent
{
    public LiteratureElementModel[] Elements { get; set; } = null!;
    public override Type EntityType => typeof(LiteratureWidget);
}
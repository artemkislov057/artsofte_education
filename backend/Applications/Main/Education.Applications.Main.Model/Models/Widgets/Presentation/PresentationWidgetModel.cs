using Education.DataBase.Entities.Widgets;

namespace Education.Applications.Main.Model.Models.Widgets.Presentation;

public class PresentationWidgetModel : WidgetContent
{
    public LiteratureSlide[] Slides { get; set; }
    public override Type EntityType => typeof(PresentationWidget);
}
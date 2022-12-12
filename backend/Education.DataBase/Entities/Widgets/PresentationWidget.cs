using Education.DataBase.Entities.Widgets.WidgetContent;
using Education.DataBase.Enums.Widgets;

namespace Education.DataBase.Entities.Widgets;

public class PresentationWidget : WidgetDetailsBase
{
    public ICollection<PresentationSlide> PresentationSlides { get; set; }

    public override WidgetType GetWidgetType()
    {
        return WidgetType.Presentation;
    }
}
using Education.DataBase.Entities.Widgets.WidgetContent;
using Education.DataBase.Enums.Widgets;

namespace Education.DataBase.Entities.Widgets;

public class LiteratureWidget : WidgetDetailsBase
{
    public ICollection<LiteratureElement> LiteratureElements { get; set; } = null!;

    public override WidgetType GetWidgetType()
    {
        return WidgetType.Literature;
    }
}
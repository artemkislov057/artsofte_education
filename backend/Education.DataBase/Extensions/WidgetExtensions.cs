using Education.DataBase.Entities.Widgets;

namespace Education.DataBase.Extensions;

public static class WidgetExtensions
{
    public static void SetWidgetDetails(this Widget source, WidgetDetailsBase details)
    {
        switch (details)
        {
            case LiteratureWidget literatureWidget:
                source.LiteratureWidget = literatureWidget;
                break;
            case PresentationWidget presentationWidget:
                source.PresentationWidget = presentationWidget;
                break;
            case VideoWidget videoWidget:
                source.VideoWidget = videoWidget;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(details));
        }
    }
}
using Education.DataBase.Enums.Widgets;

namespace Education.DataBase.Entities.Widgets;

public class VideoWidget : WidgetDetailsBase
{
    public VideoType VideoType { get; set; }
    public string Src { get; set; } = null!;

    public override WidgetType GetWidgetType()
    {
        return WidgetType.Video;
    }
}
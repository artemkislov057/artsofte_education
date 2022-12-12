using Education.DataBase.Entities.Widgets;

namespace Education.Applications.Main.Model.Models.Widgets.Video;

public class VideoWidgetModel : WidgetContent
{
    public VideoTypeModel VideoType { get; set; }
    public string Src { get; set; }
    public override Type EntityType => typeof(VideoWidget);
}
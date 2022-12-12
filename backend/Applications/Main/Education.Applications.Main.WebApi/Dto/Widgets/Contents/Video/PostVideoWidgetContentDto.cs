using Education.Applications.Main.Model.Models.Widgets.Video;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Widgets.Contents.Video;

[WidgetDtoType(WidgetTypeDto.Video)]
public class PostVideoWidgetContentDto : WidgetContentBaseDto
{
    public override Type GetModelWidgetContentType() => typeof(VideoWidgetModel);
    public VideoTypeDto VideoType { get; init; }
    public string Src { get; init; }
}
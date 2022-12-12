using Education.Applications.Main.Model.Models.Widgets.Video;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Widgets.Contents.Video;

[WidgetDtoType(WidgetTypeDto.Video)]
public record PostVideoWidgetContentDto(VideoTypeDto VideoType, string Src) : WidgetContentBaseDto
{
    public override Type ModelWidgetContentType => typeof(VideoWidgetModel);
}
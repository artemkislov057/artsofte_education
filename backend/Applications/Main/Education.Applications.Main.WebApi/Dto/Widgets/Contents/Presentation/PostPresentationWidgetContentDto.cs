using Education.Applications.Main.Model.Models.Widgets.Presentation;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Widgets.Contents.Presentation;

[WidgetDtoType(WidgetTypeDto.Presentation)]
public class PostPresentationWidgetContentDto : WidgetContentBaseDto
{
    public override Type GetModelWidgetContentType() => typeof(PresentationWidgetModel);
    public PresentationSlideDto[] Slides { get; set; }
}
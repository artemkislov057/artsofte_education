using Education.Applications.Main.Model.Models.Widgets.Presentation;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Widgets.Contents.Presentation;

[WidgetDtoType(WidgetTypeDto.Presentation)]
public record PostPresentationWidgetContentDto(PresentationSlideDto[] Slides) : WidgetContentBaseDto
{
    public override Type ModelWidgetContentType => typeof(PresentationWidgetModel);
}
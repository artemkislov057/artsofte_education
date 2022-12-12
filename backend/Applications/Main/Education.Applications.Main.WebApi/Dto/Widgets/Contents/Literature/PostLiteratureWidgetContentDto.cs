using Education.Applications.Main.Model.Models.Widgets.Literature;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Widgets.Contents.Literature;

[WidgetDtoType(WidgetTypeDto.Literature)]
public record PostLiteratureWidgetContentDto(LiteratureElementDto[] Elements) : WidgetContentBaseDto
{
    public override Type ModelWidgetContentType => typeof(LiteratureWidgetModel);
}
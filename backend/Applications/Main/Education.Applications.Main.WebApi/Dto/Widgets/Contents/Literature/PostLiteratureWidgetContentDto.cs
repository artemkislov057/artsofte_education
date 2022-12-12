using Education.Applications.Main.Model.Models.Widgets.Literature;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Widgets.Contents.Literature;

[WidgetDtoType(WidgetTypeDto.Literature)]
public class PostLiteratureWidgetContentDto : WidgetContentBaseDto
{
    public override Type GetModelWidgetContentType() => typeof(LiteratureWidgetModel);
    public LiteratureElementDto[] Elements { get; set; }
}
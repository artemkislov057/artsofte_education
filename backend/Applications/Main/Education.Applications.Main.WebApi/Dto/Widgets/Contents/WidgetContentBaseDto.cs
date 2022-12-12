namespace Education.Applications.Main.WebApi.Dto.Widgets.Contents;

public abstract record WidgetContentBaseDto
{
    public abstract Type ModelWidgetContentType { get; }
}
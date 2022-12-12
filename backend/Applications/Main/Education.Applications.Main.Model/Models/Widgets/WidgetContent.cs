namespace Education.Applications.Main.Model.Models.Widgets;

public abstract class WidgetContent
{
    public int Id { get; set; }
    public abstract Type EntityType { get; }
}
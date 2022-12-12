using Education.DataBase.Enums.Widgets;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Widgets;

public class Widget : IOrderElement
{
    public int Id { get; set; }
    public int Order { get; set; }
    public WidgetType Type { get; set; }

    public Guid ChapterId { get; set; }
    public Chapter? Chapter { get; set; }

    public VideoWidget? VideoWidget { get; set; }
    public PresentationWidget? PresentationWidget { get; set; }
    public LiteratureWidget? LiteratureWidget { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Widgets.WidgetContent;

public class PresentationSlide : IOrderElement
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string ImageSrc { get; set; } = null!;
    public string? Description { get; set; }
    public string? VoiceSrc { get; set; }

    public int PresentationId { get; set; }
    [ForeignKey(nameof(PresentationId))] public PresentationWidget PresentationWidget { get; set; } = null!;
}
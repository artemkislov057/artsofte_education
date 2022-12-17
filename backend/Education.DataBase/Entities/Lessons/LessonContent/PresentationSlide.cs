using System.ComponentModel.DataAnnotations.Schema;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Lessons.LessonContent;

public class PresentationSlide : IOrderEntity<int>
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string ImageSrc { get; set; } = null!;
    public string? Description { get; set; }
    public string? VoiceSrc { get; set; }

    public int PresentationId { get; set; }
    [ForeignKey(nameof(PresentationId))] public PresentationLesson PresentationLesson { get; set; } = null!;
}
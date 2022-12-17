using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Lessons.LessonContent;

public class LiteratureElement : IOrderEntity<int>
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CoverSrc { get; set; }

    public int LiteratureLessonId { get; set; }
    public LiteratureLesson LiteratureLesson { get; set; } = null!;

    public ICollection<LiteraturePurchaseLink> PurchaseLinks { get; set; } = null!;
}
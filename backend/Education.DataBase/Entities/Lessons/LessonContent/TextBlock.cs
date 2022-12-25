using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Lessons.LessonContent;

public class TextBlock : IOrderEntity<int>
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string BlockId { get; set; }
    public string Type { get; set; }
    public string? DataText { get; set; }
    public int? DataLevel { get; set; }
    public string? DataStyle { get; set; }
    public ICollection<ListItem>? DataItems { get; set; }

    public EditorJsObject EditorJsObject { get; set; } = null!;
}
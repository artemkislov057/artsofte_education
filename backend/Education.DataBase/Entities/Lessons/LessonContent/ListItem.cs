using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities.Lessons.LessonContent;

public class ListItem : IOrderEntity<int>
{
    public int Id { get; set; }
    public int Order { get; set; }

    public string Value { get; set; } = null!;

    public int TextBlockId { get; set; }
    public TextBlock TextBlock { get; set; } = null!;
}
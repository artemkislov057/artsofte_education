using Education.DataBase.Entities.Widgets;

namespace Education.DataBase.Entities;

public class Chapter
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Guid CourseId { get; set; }
    public Course? Course { get; set; }

    public ICollection<Widget>? Widgets { get; set; }
}
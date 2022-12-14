using Education.DataBase.Entities.Lessons;
using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities;

public class Module : IOrderElement
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Guid CourseId { get; set; }
    public Course? Course { get; set; }

    public ICollection<Lesson>? Lessons { get; set; }
}
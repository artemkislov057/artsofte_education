using Education.DataBase.Interfaces;

namespace Education.DataBase.Entities;

public class Course : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;

    public ICollection<Module>? Modules { get; set; }
}
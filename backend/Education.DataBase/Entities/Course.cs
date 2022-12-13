namespace Education.DataBase.Entities;

public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<Module>? Modules { get; set; }
}
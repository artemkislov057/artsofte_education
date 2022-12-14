namespace Education.Applications.Main.Model.Models.Lessons;

public abstract class LessonContent
{
    public int Id { get; set; }
    public abstract Type EntityType { get; }
}
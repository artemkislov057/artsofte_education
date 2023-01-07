using Education.Applications.Main.Model.Models.EditorJs;

namespace Education.Applications.Main.Model.Models.Lessons;

public abstract class LessonContent
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EditorJsObjectModel? AdditionalText { get; set; }
    public abstract Type? EntityType { get; }
}

public sealed class LessonContentEmpty : LessonContent
{
    public override Type? EntityType => null;
}
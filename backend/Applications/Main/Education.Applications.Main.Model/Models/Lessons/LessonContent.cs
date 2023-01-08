using Education.Applications.Main.Model.Models.EditorJs;
using Education.DataBase.Enums.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons;

public abstract class LessonContent
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EditorJsObjectModel? AdditionalText { get; set; }
    public abstract Type EntityType { get; }
    public abstract LessonType LessonType { get; }
}
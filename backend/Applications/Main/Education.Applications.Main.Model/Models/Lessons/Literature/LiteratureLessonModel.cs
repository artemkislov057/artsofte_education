using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Literature;

public class LiteratureLessonModel : LessonContent
{
    public LiteratureElementModel[] Elements { get; set; } = null!;
    public override Type EntityType => typeof(LiteratureLesson);
}
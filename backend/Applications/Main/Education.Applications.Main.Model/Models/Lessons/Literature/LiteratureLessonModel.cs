using Education.DataBase.Entities.Lessons;
using Education.DataBase.Enums.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Literature;

public class LiteratureLessonModel : LessonContent
{
    public LiteratureElementModel[] Elements { get; set; } = null!;
    public override Type EntityType => typeof(LiteratureLesson);
    public override LessonType LessonType => LessonType.Literature;
}
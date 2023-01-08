using Education.DataBase.Entities.Lessons;
using Education.DataBase.Enums.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Presentation;

public class PresentationLessonModel : LessonContent
{
    public LiteratureSlide[] Slides { get; set; }
    public override Type EntityType => typeof(PresentationLesson);
    public override LessonType LessonType => LessonType.Presentation;
}
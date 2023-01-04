using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Presentation;

public class PresentationLessonModel : LessonContent
{
    public LiteratureSlide[] Slides { get; set; }
    public override string GetLessonDisplayType => "Презентация";
    public override Type EntityType => typeof(PresentationLesson);
}
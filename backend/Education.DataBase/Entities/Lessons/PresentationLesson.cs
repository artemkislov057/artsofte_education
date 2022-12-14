using Education.DataBase.Entities.Lessons.LessonContent;
using Education.DataBase.Enums.Lessons;

namespace Education.DataBase.Entities.Lessons;

public class PresentationLesson : LessonDetailsBase
{
    public ICollection<PresentationSlide> PresentationSlides { get; set; }

    public override LessonType GetLessonType()
    {
        return LessonType.Presentation;
    }
}
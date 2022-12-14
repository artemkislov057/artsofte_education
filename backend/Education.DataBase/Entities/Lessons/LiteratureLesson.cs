using Education.DataBase.Entities.Lessons.LessonContent;
using Education.DataBase.Enums.Lessons;

namespace Education.DataBase.Entities.Lessons;

public class LiteratureLesson : LessonDetailsBase
{
    public ICollection<LiteratureElement> LiteratureElements { get; set; } = null!;

    public override LessonType GetLessonType()
    {
        return LessonType.Literature;
    }
}
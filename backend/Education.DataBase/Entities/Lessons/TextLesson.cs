using Education.DataBase.Entities.Lessons.LessonContent;
using Education.DataBase.Enums.Lessons;

namespace Education.DataBase.Entities.Lessons;

public class TextLesson : LessonDetailsBase
{
    public long Time { get; set; }
    public ICollection<TextBlock> Blocks { get; set; } = null!;
    public string Version { get; set; } = null!;

    public override LessonType GetLessonType()
    {
        return LessonType.Text;
    }
}
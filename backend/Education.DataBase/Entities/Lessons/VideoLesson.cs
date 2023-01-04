using Education.DataBase.Enums.Lessons;
using Education.DataBase.Enums.Lessons.Video;

namespace Education.DataBase.Entities.Lessons;

public class VideoLesson : LessonDetailsBase
{
    public VideoType VideoType { get; set; }
    public string? Src { get; set; }

    public override LessonType GetLessonType()
    {
        return LessonType.Video;
    }
}
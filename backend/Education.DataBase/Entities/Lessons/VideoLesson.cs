using Education.DataBase.Enums.Lessons;

namespace Education.DataBase.Entities.Lessons;

public class VideoLesson : LessonDetailsBase
{
    public VideoType VideoType { get; set; }
    public string Src { get; set; } = null!;

    public override LessonType GetLessonType()
    {
        return LessonType.Video;
    }
}
using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Video;

public class VideoLessonModel : LessonContent
{
    public VideoTypeModel VideoType { get; set; }
    public string Src { get; set; }
    public override Type EntityType => typeof(VideoLesson);
}
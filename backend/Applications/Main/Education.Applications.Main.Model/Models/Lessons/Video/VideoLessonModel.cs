using System.ComponentModel.DataAnnotations;
using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Video;

public class VideoLessonModel : LessonContent
{
    public VideoTypeModel VideoType { get; set; }
    [Display(Name = "Ссылка на видео")] public string Src { get; set; }
    public override string GetLessonDisplayType => "Видео";
    public override Type EntityType => typeof(VideoLesson);
}
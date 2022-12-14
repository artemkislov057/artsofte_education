using Education.Applications.Main.Model.Models.Lessons.Video;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Video;

[LessonDtoType(LessonTypeDto.Video)]
public class PostVideoLessonContentDto : LessonContentBaseDto
{
    public override Type GetModelLessonContentType() => typeof(VideoLessonModel);
    public VideoTypeDto VideoType { get; init; }
    public string Src { get; init; }
}
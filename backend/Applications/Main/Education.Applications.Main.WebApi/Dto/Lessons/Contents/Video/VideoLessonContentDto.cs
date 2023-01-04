using Education.Applications.Main.Model.Models.Lessons.Video;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Video;

/// <summary>
/// Модель видео-урока
/// </summary>
[LessonDtoType(LessonTypeDto.Video)]
public class VideoLessonContentDto : LessonContentBaseDto
{
    public override Type GetModelLessonContentType() => typeof(VideoLessonModel);
    
    /// <summary>
    /// Тип источника видео
    /// </summary>
    public VideoTypeDto VideoType { get; init; }
    
    /// <summary>
    /// Ссылка на видео
    /// </summary>
    public string? Src { get; init; }
}
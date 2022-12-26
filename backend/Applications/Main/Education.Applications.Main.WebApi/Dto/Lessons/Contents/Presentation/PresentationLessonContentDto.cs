using Education.Applications.Main.Model.Models.Lessons.Presentation;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Presentation;

/// <summary>
/// Модель урока презентации
/// </summary>
[LessonDtoType(LessonTypeDto.Presentation)]
public class PresentationLessonContentDto : LessonContentBaseDto
{
    public override Type GetModelLessonContentType() => typeof(PresentationLessonModel);

    /// <summary>
    /// Массив слайдов
    /// </summary>
    public PresentationSlideDto[] Slides { get; set; } = null!;
}
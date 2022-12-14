using Education.Applications.Main.Model.Models.Lessons.Literature;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Literature;

/// <summary>
/// Модель урока списка литературы
/// </summary>
[LessonDtoType(LessonTypeDto.Literature)]
public class LiteratureLessonContentDto : LessonContentBaseDto
{
    public override Type GetModelLessonContentType() => typeof(LiteratureLessonModel);
    
    /// <summary>
    /// Массив книг
    /// </summary>
    public LiteratureElementDto[] Elements { get; set; }
}
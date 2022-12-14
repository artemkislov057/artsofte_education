using Education.Applications.Main.Model.Models.Lessons.Literature;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Literature;

[LessonDtoType(LessonTypeDto.Literature)]
public class PostLiteratureLessonContentDto : LessonContentBaseDto
{
    public override Type GetModelLessonContentType() => typeof(LiteratureLessonModel);
    public LiteratureElementDto[] Elements { get; set; }
}
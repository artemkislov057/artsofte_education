using Education.Applications.Main.Model.Models.Lessons.Presentation;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Presentation;

[LessonDtoType(LessonTypeDto.Presentation)]
public class PostPresentationLessonContentDto : LessonContentBaseDto
{
    public override Type GetModelLessonContentType() => typeof(PresentationLessonModel);
    public PresentationSlideDto[] Slides { get; set; }
}
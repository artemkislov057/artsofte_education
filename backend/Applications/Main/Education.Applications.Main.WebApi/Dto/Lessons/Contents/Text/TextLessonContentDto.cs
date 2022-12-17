using Education.Applications.Main.Model.Models.Lessons.Text;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;

[LessonDtoType(LessonTypeDto.Text)]
public sealed class TextLessonContentDto : LessonContentBaseDto
{
    public string Value { get; set; }

    public override Type GetModelLessonContentType()
    {
        return typeof(TextLessonModel);
    }
}
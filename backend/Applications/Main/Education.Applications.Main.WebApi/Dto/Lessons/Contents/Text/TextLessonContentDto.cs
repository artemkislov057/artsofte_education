using Education.Applications.Main.Model.Models.Lessons.Text;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;

/// <summary>
/// Модель текстового урока
/// </summary>
[LessonDtoType(LessonTypeDto.Text)]
public sealed class TextLessonContentDto : LessonContentBaseDto
{
    public long Time { get; set; }
    public TextBlockDto[] Blocks { get; set; } = null!;
    public string Version { get; set; } = null!;

    public override Type GetModelLessonContentType()
    {
        return typeof(TextLessonModel);
    }
}
using Education.Applications.Main.Model.Models.Lessons.Test;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Test;

[LessonDtoType(LessonTypeDto.Test)]
public class TestLessonContentDto : LessonContentBaseDto
{
    public TestQuestionDto[] Questions { get; set; } = null!;
    public override Type GetModelLessonContentType() => typeof(TestLessonModel);
}
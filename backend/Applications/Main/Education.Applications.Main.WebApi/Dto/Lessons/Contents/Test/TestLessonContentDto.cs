using Education.Applications.Main.Model.Models.Lessons.Test;
using Education.Applications.Main.WebApi.Attributes;

namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Test;

/// <summary>
/// Модель урока-теста
/// </summary>
[LessonDtoType(LessonTypeDto.Test)]
public class TestLessonContentDto : LessonContentBaseDto
{
    /// <summary>
    /// Вопросы
    /// </summary>
    public TestQuestionDto[] Questions { get; set; } = null!;
    public override Type GetModelLessonContentType() => typeof(TestLessonModel);
}
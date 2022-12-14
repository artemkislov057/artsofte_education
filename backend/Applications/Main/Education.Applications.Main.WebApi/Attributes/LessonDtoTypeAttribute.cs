using Education.Applications.Main.WebApi.Dto.Lessons;

namespace Education.Applications.Main.WebApi.Attributes;

public class LessonDtoTypeAttribute : Attribute
{
    public LessonTypeDto LessonType { get; }

    public LessonDtoTypeAttribute(LessonTypeDto lessonType)
    {
        LessonType = lessonType;
    }
}
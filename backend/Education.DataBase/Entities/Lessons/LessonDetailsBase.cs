using System.ComponentModel.DataAnnotations;
using Education.DataBase.Enums.Lessons;

namespace Education.DataBase.Entities.Lessons;

public abstract class LessonDetailsBase
{
    [Key] public int LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;

    public abstract LessonType GetLessonType();
}
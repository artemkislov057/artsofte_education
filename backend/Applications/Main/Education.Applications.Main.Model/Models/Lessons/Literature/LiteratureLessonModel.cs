using System.ComponentModel.DataAnnotations;
using Education.DataBase.Entities.Lessons;

namespace Education.Applications.Main.Model.Models.Lessons.Literature;

public class LiteratureLessonModel : LessonContent
{
    [Display(Name = "Книги")] public LiteratureElementModel[] Elements { get; set; } = null!;
    public override string GetLessonDisplayType => "Список литературы";
    public override Type EntityType => typeof(LiteratureLesson);
}
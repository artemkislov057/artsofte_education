using System.ComponentModel.DataAnnotations;
using Education.Applications.Main.Model.Models.EditorJs;

namespace Education.Applications.Main.Model.Models.Lessons;

public abstract class LessonContent
{
    [Display(Name = "Идентификатор")] public int Id { get; set; }
    [Display(Name = "Название лекции")] public string Name { get; set; }
    [Display(Name = "Тип лекции")] public abstract string GetLessonDisplayType { get; }
    public EditorJsObjectModel? AdditionalText { get; set; }
    public abstract Type EntityType { get; }
}
using System.ComponentModel.DataAnnotations;
using Education.Applications.Main.Model.Models.Lessons;

namespace Education.Applications.Main.Model.Models.Modules;

public class ModuleModel
{
    [Display(Name = "Идентификатор")] public Guid Id { get; set; }
    [Display(Name = "Название модуля")] public string Name { get; set; }
    [Display(Name = "Описание модуля")] public string Description { get; set; }
    public LessonContent[] Lessons { get; set; }
}
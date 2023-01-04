using System.ComponentModel.DataAnnotations;
using Education.Applications.Main.Model.Models.Modules;

namespace Education.Applications.Main.Model.Models.Courses;

public class CourseModel
{
    [Display(Name = "Идентификатор")] public Guid Id { get; set; }
    [Display(Name = "Название курса")] public string Name { get; set; }
    [Display(Name = "Описание курса")] public string Description { get; set; }
    public ModuleModel[] Modules { get; set; }
}
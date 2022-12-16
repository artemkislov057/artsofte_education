using Education.Applications.Main.Model.Models.Modules;

namespace Education.Applications.Main.Model.Models.Courses;

public class CourseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ModuleModel[] Modules { get; set; }
}
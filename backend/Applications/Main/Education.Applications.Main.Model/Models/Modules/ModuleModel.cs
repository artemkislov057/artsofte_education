using Education.Applications.Main.Model.Models.Lessons;

namespace Education.Applications.Main.Model.Models.Modules;

public class ModuleModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public LessonContent[] Lessons { get; set; }
}
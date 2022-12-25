using Education.Applications.Main.Model.Models.Lessons.Text;

namespace Education.Applications.Main.Model.Models.EditorJs;

public class EditorJsObjectModel
{
    public long Time { get; set; }
    public TextBlockModel[] Blocks { get; set; } = null!;
    public string Version { get; set; } = null!;
}
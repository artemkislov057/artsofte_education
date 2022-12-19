namespace Education.Applications.Main.Model.Models.Lessons.Text;

public class TextBlockModel
{
    public string Id { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string? DataText { get; set; }
    public int? DataLevel { get; set; }
    public string? DataStyle { get; set; }
    public string[]? DataItems { get; set; }
}
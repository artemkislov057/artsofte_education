namespace Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;

public class TextBlockDto
{
    public string Id { get; set; } = null!;
    public string Type { get; set; } = null!;
    public TextBlockDataDto Data { get; set; } = null!;
}
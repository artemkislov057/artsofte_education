using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;

namespace Education.Applications.Main.WebApi.Dto.EditorJs;

public sealed record EditorJsDto(long Time, TextBlockDto[] Blocks, string Version);
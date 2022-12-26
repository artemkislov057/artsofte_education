using Education.Applications.Main.Model.Models.Lessons.Text;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;
using Mapster;

namespace Education.Applications.Main.WebApi.MapsterConfigs;

public class TextBlockDtoConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TextBlockModel, TextBlockDto>()
            .Map("Data.Text", "DataText")
            .Map("Data.Level", "DataLevel")
            .Map("Data.Style", "DataStyle")
            .Map("Data.Items", "DataItems");
    }
}
using Education.Applications.Main.Model.Models.Lessons.Text;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;
using Mapster;

namespace Education.Applications.Main.WebApi.MapsterConfigs;

public class TextBlockDtoConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TextBlockModel, TextBlockDto>()
            .Map(dest => dest.Data.Text, source => source.DataText)
            .Map(dest => dest.Data.Level, source => source.DataLevel)
            .Map(dest => dest.Data.Style, source => source.DataStyle)
            .Map(dest => dest.Data.Items, source => source.DataItems);
    }
}
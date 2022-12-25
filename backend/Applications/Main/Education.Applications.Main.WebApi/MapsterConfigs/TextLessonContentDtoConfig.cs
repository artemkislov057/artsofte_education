using Education.Applications.Main.Model.Models.Lessons.Text;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;
using Mapster;

namespace Education.Applications.Main.WebApi.MapsterConfigs;

public class TextLessonContentDtoConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TextLessonContentDto, TextLessonModel>()
            .TwoWays()
            .Map(dest => dest.Value, source => source);
    }
}
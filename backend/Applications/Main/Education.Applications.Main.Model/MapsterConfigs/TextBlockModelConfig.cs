using Education.Applications.Main.Model.Models.Lessons.Text;
using Education.DataBase.Entities.Lessons.LessonContent;
using Mapster;

namespace Education.Applications.Main.Model.MapsterConfigs;

public class TextBlockModelConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TextBlockModel, TextBlock>()
            .Ignore(m => m.Id)
            .Map(dest => dest.BlockId, source => source.Id)
            .Map(dest => dest.DataItems,
                source => source.DataItems == null ? null : source.DataItems.Select(i => new ListItem { Value = i }));

        config.NewConfig<TextBlock, TextBlockModel>()
            .Map(dest => dest.Id, source => source.BlockId)
            .Map(dest => dest.DataItems,
                source => source.DataItems == null || source.DataItems.Count == 0
                    ? null
                    : source.DataItems.Select(i => i.Value));
    }
}
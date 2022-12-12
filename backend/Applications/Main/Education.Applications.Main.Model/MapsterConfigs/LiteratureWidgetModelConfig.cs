using Education.Applications.Main.Model.Models.Widgets.Literature;
using Education.DataBase.Entities.Widgets;
using Mapster;

namespace Education.Applications.Main.Model.MapsterConfigs;

public class LiteratureWidgetModelConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LiteratureWidgetModel, LiteratureWidget>()
            .TwoWays()
            .Map(dest => dest.LiteratureElements, source => source.Elements);
    }
}
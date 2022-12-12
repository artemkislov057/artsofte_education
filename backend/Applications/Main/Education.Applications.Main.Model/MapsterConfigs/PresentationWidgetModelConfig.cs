using Education.Applications.Main.Model.Models.Widgets.Presentation;
using Education.DataBase.Entities.Widgets;
using Mapster;

namespace Education.Applications.Main.Model.MapsterConfigs;

public class PresentationWidgetModelConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PresentationWidgetModel, PresentationWidget>()
            .TwoWays()
            .Map(dest => dest.PresentationSlides, source => source.Slides);
    }
}
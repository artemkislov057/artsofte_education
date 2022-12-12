using Education.Applications.Main.Model.Models.Widgets.Literature;
using Education.DataBase.Entities.Widgets.WidgetContent;
using Mapster;

namespace Education.Applications.Main.Model.MapsterConfigs;

public class LiteratureElementModelConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LiteratureElementModel, LiteratureElement>()
            .Map(dest => dest.PurchaseLinks,
                source => source.PurchaseLinks.Select(l => new LiteraturePurchaseLink { Value = l }));
    }
}
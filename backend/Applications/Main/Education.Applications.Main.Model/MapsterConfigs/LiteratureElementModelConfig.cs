using Education.Applications.Main.Model.Models.Lessons.Literature;
using Education.DataBase.Entities.Lessons.LessonContent;
using Mapster;

namespace Education.Applications.Main.Model.MapsterConfigs;

public class LiteratureElementModelConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LiteratureElementModel, LiteratureElement>()
            .Map(dest => dest.PurchaseLinks,
                source => source.PurchaseLinks.Select(l => new LiteraturePurchaseLink { Value = l }));

        config.NewConfig<LiteratureElement, LiteratureElementModel>()
            .Map(dest => dest.PurchaseLinks,
                source => source.PurchaseLinks.Select(l => l.Value));
    }
}
using Education.Applications.Main.Model.Models.Lessons.Literature;
using Education.DataBase.Entities.Lessons;
using Mapster;

namespace Education.Applications.Main.Model.MapsterConfigs;

public class LiteratureLessonModelConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LiteratureLessonModel, LiteratureLesson>()
            .TwoWays()
            .Map(dest => dest.LiteratureElements, source => source.Elements);
    }
}
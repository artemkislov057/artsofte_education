using Education.Applications.Main.Model.Models.Lessons.Presentation;
using Education.DataBase.Entities.Lessons;
using Mapster;

namespace Education.Applications.Main.Model.MapsterConfigs;

public class PresentationLessonModelConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PresentationLessonModel, PresentationLesson>()
            .TwoWays()
            .Map(dest => dest.PresentationSlides, source => source.Slides);
    }
}
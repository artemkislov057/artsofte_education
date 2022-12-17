using Education.Applications.Main.Model.Models.Modules;
using Education.Applications.Main.WebApi.Dto.Modules;
using Mapster;

namespace Education.Applications.Main.WebApi.MapsterConfigs;

public class ModuleDtoConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ModuleModel, ModuleDto>()
            .Ignore(m => m.Lessons!);
    }
}
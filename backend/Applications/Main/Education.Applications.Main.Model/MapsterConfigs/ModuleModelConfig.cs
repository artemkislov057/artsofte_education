using Education.Applications.Main.Model.Models.Modules;
using Education.DataBase.Entities;
using Mapster;

namespace Education.Applications.Main.Model.MapsterConfigs;

public class ModuleModelConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Module, ModuleModel>()
            .Ignore(m => m.Lessons);
    }
}
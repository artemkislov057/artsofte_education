using Education.Applications.Main.Model.Models.Modules;
using Education.Applications.Main.Model.Services.EventSender.Extensions;

namespace Education.Applications.Main.Model.Services.EventSender.Events.Module;

public class ModuleAddEvent : IEvent
{
    private readonly string courseName;
    private readonly ModuleModel module;

    public ModuleAddEvent(string courseName, ModuleModel module)
    {
        this.courseName = courseName;
        this.module = module;
    }

    public string GetMessage()
        => $"В курс \"{courseName}\" добавлен модуль\n*****\n{module.GetModelDescription()}";
}
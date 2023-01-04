using Education.Applications.Main.Model.Models.Modules;
using Education.Applications.Main.Model.Services.EventSender.Extensions;

namespace Education.Applications.Main.Model.Services.EventSender.Events.Module;

public class ModuleEditEvent : IEvent
{
    private readonly string courseName;
    private readonly ModuleModel module;

    public ModuleEditEvent(string courseName, ModuleModel module)
    {
        this.courseName = courseName;
        this.module = module;
    }

    public string GetMessage()
        => $"В курсе \"{courseName}\" редактирован модуль\n*****\n{module.GetModelDescription()}";
}
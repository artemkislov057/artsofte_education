namespace Education.Applications.Main.Model.Services.EventSender.Events.Module;

public class ModuleDeleteEvent : IEvent
{
    private readonly string courseName;
    private readonly string moduleName;

    public ModuleDeleteEvent(string courseName, string moduleName)
    {
        this.courseName = courseName;
        this.moduleName = moduleName;
    }

    public string GetMessage()
        => $"Из курса \"{courseName}\" удалён модуль {moduleName}";
}
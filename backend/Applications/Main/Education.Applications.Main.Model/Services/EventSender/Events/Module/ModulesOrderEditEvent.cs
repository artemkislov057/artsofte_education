namespace Education.Applications.Main.Model.Services.EventSender.Events.Module;

public class ModulesOrderEditEvent : IEvent
{
    private readonly string courseName;
    private readonly string[] moduleNames;

    public ModulesOrderEditEvent(string courseName, string[] moduleNames)
    {
        this.courseName = courseName;
        this.moduleNames = moduleNames;
    }

    public string GetMessage()
        => $"В курсе \"{courseName}\" изменён порядок модулей.\n" +
           "Новый порядок:\n" +
           string.Join('\n', moduleNames);
}
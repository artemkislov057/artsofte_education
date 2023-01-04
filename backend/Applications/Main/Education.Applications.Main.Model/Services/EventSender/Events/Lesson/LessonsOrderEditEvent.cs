namespace Education.Applications.Main.Model.Services.EventSender.Events.Lesson;

public class LessonsOrderEditEvent : IEvent
{
    private readonly string courseName;
    private readonly string moduleName;
    private readonly string[] lessonNames;

    public LessonsOrderEditEvent(string courseName, string moduleName, string[] lessonNames)
    {
        this.courseName = courseName;
        this.moduleName = moduleName;
        this.lessonNames = lessonNames;
    }

    public string GetMessage()
        => $"В курсе \"{courseName}\" в модуле \"{moduleName}\" изменён порядок уроков.\n" +
           "Новый порядок:\n" +
           string.Join('\n', lessonNames);
}
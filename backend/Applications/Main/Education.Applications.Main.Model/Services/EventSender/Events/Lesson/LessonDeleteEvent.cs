using Education.Applications.Main.Model.Models.Lessons;

namespace Education.Applications.Main.Model.Services.EventSender.Events.Lesson;

public class LessonDeleteEvent : IEvent
{
    private readonly string courseName;
    private readonly string moduleName;
    private readonly string lessonName;

    public LessonDeleteEvent(string courseName, string moduleName, string lessonName)
    {
        this.courseName = courseName;
        this.moduleName = moduleName;
        this.lessonName = lessonName;
    }

    public string GetMessage()
        => $"В курсе \"{courseName}\" в модуле \"{moduleName}\" удалён урок {lessonName}";
}
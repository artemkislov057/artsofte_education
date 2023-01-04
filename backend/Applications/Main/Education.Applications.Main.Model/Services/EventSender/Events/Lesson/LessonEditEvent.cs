using Education.Applications.Main.Model.Models.Lessons;
using Education.Applications.Main.Model.Services.EventSender.Extensions;

namespace Education.Applications.Main.Model.Services.EventSender.Events.Lesson;

public class LessonEditEvent : IEvent
{
    private readonly string courseName;
    private readonly string moduleName;
    private readonly LessonContent lesson;

    public LessonEditEvent(string courseName, string moduleName, LessonContent lesson)
    {
        this.courseName = courseName;
        this.moduleName = moduleName;
        this.lesson = lesson;
    }

    public string GetMessage()
        => $"В курсе \"{courseName}\" в модуле \"{moduleName}\" редактирован урок.\n*****\n{lesson.GetModelDescription()}";
}
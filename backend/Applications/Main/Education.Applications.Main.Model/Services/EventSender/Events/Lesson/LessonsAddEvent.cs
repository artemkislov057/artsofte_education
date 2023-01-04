using Education.Applications.Main.Model.Models.Lessons;
using Education.Applications.Main.Model.Services.EventSender.Extensions;

namespace Education.Applications.Main.Model.Services.EventSender.Events.Lesson;

public class LessonAddEvent : IEvent
{
    private readonly string courseName;
    private readonly string moduleName;
    private readonly LessonContent[] lessons;

    public LessonAddEvent(string courseName, string moduleName, LessonContent[] lessons)
    {
        this.courseName = courseName;
        this.moduleName = moduleName;
        this.lessons = lessons;
    }

    public string GetMessage()
        => $"В курсе \"{courseName}\" в модуль \"{moduleName}\" добавлены уроки.\n*****\n" +
           string.Join("\n\n", lessons.Select(l => l.GetModelDescription()));
}
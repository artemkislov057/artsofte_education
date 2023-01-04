namespace Education.Applications.Main.Model.Services.EventSender.Events.Course;

public class CourseDeleteEvent : IEvent
{
    private readonly Guid id;
    private readonly string name;

    public CourseDeleteEvent(Guid id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public string GetMessage() => $"Курс \"{name}\" удалён. Идентификатор: {id}";
}
using Education.Applications.Main.Model.Models.Courses;
using Education.Applications.Main.Model.Services.EventSender.Extensions;

namespace Education.Applications.Main.Model.Services.EventSender.Events.Course;

public sealed class CourseAddEvent : IEvent
{
    private readonly CourseModel course;

    public CourseAddEvent(CourseModel course) => this.course = course;

    public string GetMessage() => "Создан курс\n" + course.GetModelDescription();
}
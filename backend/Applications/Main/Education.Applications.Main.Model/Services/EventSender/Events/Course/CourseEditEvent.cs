using Education.Applications.Main.Model.Models.Courses;
using Education.Applications.Main.Model.Services.EventSender.Extensions;

namespace Education.Applications.Main.Model.Services.EventSender.Events.Course;

public sealed class CourseEditEvent : IEvent
{
    private readonly CourseModel course;

    public CourseEditEvent(CourseModel course) => this.course = course;

    public string GetMessage() => "Редактирован курс\n" + course.GetModelDescription();
}
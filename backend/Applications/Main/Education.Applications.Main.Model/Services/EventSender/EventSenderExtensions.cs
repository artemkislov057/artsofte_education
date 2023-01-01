using Education.Applications.Main.Model.Services.EventSender.Events;

namespace Education.Applications.Main.Model.Services.EventSender;

public static class EventSenderExtensions
{
    public static void Send(this IEnumerable<EventSender> eventSenders, IEvent @event)
    {
        foreach (var eventSender in eventSenders)
        {
            eventSender.Send(@event);
        }
    }
}
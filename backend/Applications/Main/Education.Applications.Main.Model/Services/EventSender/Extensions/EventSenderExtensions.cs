using Education.Applications.Main.Model.Services.EventSender.Events;

namespace Education.Applications.Main.Model.Services.EventSender.Extensions;

public static class EventSenderExtensions
{
    public static async Task Send(this IEnumerable<EventSender> eventSenders, IEvent @event)
    {
        foreach (var eventSender in eventSenders)
        {
            await eventSender.Send(@event);
        }
    }
}
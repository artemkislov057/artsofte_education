using Education.Applications.Main.Model.Services.EventSender.Events;

namespace Education.Applications.Main.Model.Services.EventSender;

public abstract class EventSender
{
    public async Task Send(IEvent @event)
    {
        await Send(@event.GetMessage());
    }

    protected abstract Task Send(string message);
}
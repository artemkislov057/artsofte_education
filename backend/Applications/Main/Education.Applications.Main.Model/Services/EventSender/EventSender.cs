using Education.Applications.Main.Model.Services.EventSender.Events;

namespace Education.Applications.Main.Model.Services.EventSender;

public abstract class EventSender
{
    public bool Send(IEvent @event)
    {
        return Send(@event.GetMessage());
    }

    protected abstract bool Send(string message);
}
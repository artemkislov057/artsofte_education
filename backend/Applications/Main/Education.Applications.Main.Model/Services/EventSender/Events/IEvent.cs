namespace Education.Applications.Main.Model.Services.EventSender.Events;

public interface IEvent
{
    string GetMessage();
}
namespace Education.Applications.Main.WebApi.EventSenders;

public sealed class TelegramChannelSettings
{
    public string Token { get; set; } = null!;
    public long ChatId { get; set; }
}
using Education.Applications.Main.Model.Services.EventSender;
using Telegram.Bot;

namespace Education.Applications.Main.WebApi.EventSenders;

public class TelegramChannelSender : EventSender
{
    private readonly TelegramBotClient client;
    private readonly TelegramChannelSettings settings;

    public TelegramChannelSender(TelegramBotClient client, TelegramChannelSettings settings)
    {
        this.client = client;
        this.settings = settings;
    }

    protected override async Task Send(string message)
    {
        await client.SendTextMessageAsync(settings.ChatId!, message);
    }
}
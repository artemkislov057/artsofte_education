using System.Reflection;
using Education.Applications.Main.Model.Services.EventSender;
using Education.Applications.Main.WebApi.EventSenders;
using Education.Applications.Main.WebApi.Middlewares;
using LightInject;
using Telegram.Bot;

namespace Education.Applications.Main.WebApi;

public sealed class Startup : Common.StartupBase
{
    private readonly TelegramChannelSettings? telegramChannelSettings;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
        : base(configuration, env)
    {
        telegramChannelSettings = configuration.Get<EventSenderSettings>().TelegramSettings;
    }

    protected override Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();

    public override void ConfigureAdditional(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }

    public override void ConfigureContainer(IServiceContainer container)
    {
        base.ConfigureContainer(container);

        if (telegramChannelSettings != null)
        {
            container.Register<EventSender, TelegramChannelSender>(new PerContainerLifetime());
            container.Register(_ => telegramChannelSettings, new PerContainerLifetime());
            container.Register(_ => new TelegramBotClient(telegramChannelSettings.Token), new PerContainerLifetime());
        }
    }
}
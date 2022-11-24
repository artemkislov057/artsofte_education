using System.Reflection;

namespace Education.Applications.Main.WebApi;

public sealed class Startup : Common.StartupBase
{
    public Startup(IConfiguration configuration)
        : base(configuration)
    {
    }

    protected override Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();

    public override void ConfigureAdditional(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}
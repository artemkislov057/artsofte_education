using System.Reflection;

namespace Education.Applications.Main.WebApi;

public sealed class Startup : Common.StartupBase
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
        : base(configuration, env)
    {
    }

    protected override Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();

    public override void ConfigureAdditional(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}
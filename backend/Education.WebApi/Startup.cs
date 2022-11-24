using System.Reflection;
using StartupBase = Education.WebApi.Common.StartupBase;

namespace Education.WebApi;

public sealed class Startup : StartupBase
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
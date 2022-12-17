using System.Reflection;
using Education.Applications.FileLoader.WebApi.Dto;
using StartupBase = Education.Applications.Common.StartupBase;

namespace Education.Applications.FileLoader.WebApi;

public class Startup : StartupBase
{
    private readonly AppSettings appSettings;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
        : base(configuration, env)
    {
        appSettings = configuration.Get<AppSettings>();
    }

    protected override Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();

    public override void ConfigureAdditional(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }

    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        var directoryPaths = Enum.GetValues<FileTypeDto>()
            .Select(t => Path.Combine(appSettings.StorageDirectoryPath, t.ToString()))
            .ToArray();
        foreach (var directoryPath in directoryPaths)
        {
            Directory.CreateDirectory(directoryPath);
        }
    }
}
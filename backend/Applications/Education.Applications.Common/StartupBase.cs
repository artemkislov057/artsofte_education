using System.Reflection;
using System.Text.Json.Serialization;
using Education.DataBase;
using Education.Extensions.LightInject;
using LightInject;
using Mapster;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Filters;

namespace Education.Applications.Common;

public abstract class StartupBase
{
    private readonly IWebHostEnvironment environment;
    private readonly AppSettingsBase appSettings;
    protected virtual PathString ApiBase => new("/api");
    protected abstract Assembly ExecutingAssembly { get; }
    private const string StartProjectsName = "Education";

    protected StartupBase(IConfiguration configuration, IWebHostEnvironment env)
    {
        environment = env;
        appSettings = configuration.Get<AppSettingsBase>();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var isDevelopment = environment.IsDevelopment();
        var dbContext = new EducationDbContext(new DbContextOptionsBuilder<EducationDbContext>()
            .UseSqlServer(appSettings.ConnectionStrings.EducationDb).Options);
        dbContext.Database.Migrate();
        services.AddDbContext<EducationDbContext>(options =>
            options.UseSqlServer(appSettings.ConnectionStrings.EducationDb));
        services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(configure =>
            {
                configure.Password.RequiredLength = 1;
                configure.Password.RequireNonAlphanumeric = false;
                configure.Password.RequireUppercase = false;
                configure.Password.RequireLowercase = false;
                configure.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<EducationDbContext>();
        services.AddAuthentication();
        services.AddAuthorization();
        services.ConfigureApplicationCookie(configure =>
        {
            if (isDevelopment)
            {
                configure.Cookie.HttpOnly = true;
                configure.Cookie.SecurePolicy = CookieSecurePolicy.None;
                configure.Cookie.SameSite = SameSiteMode.Lax;
            }

            configure.Events = new CookieAuthenticationEvents
            {
                OnRedirectToLogin = redirectContext =>
                {
                    if (redirectContext.Request.Path.StartsWithSegments(ApiBase) &&
                        redirectContext.Response.StatusCode == 200)
                    {
                        redirectContext.Response.StatusCode = 401;
                    }

                    return Task.CompletedTask;
                },
                OnRedirectToAccessDenied = redirectContext =>
                {
                    if (redirectContext.Request.Path.StartsWithSegments(ApiBase) &&
                        redirectContext.Response.StatusCode == 200)
                    {
                        redirectContext.Response.StatusCode = 403;
                    }

                    return Task.CompletedTask;
                }
            };
        });
        services.AddRouting();
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        services.AddSwaggerGen(configure =>
        {
            configure.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = "v1",
                Title = $"{appSettings.AppName} API",
                Description = $"Public API for project \"{appSettings.AppName}\""
            });
            var xmlFile = $"{ExecutingAssembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            configure.IncludeXmlComments(xmlPath);
            configure.ExampleFilters();
            configure.EnableAnnotations();
        });
        services.AddSwaggerExamplesFromAssemblies(ExecutingAssembly);
        services.AddCors();

        ConfigureMapster();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger";
            });
        }

        app.UseCors(builder => builder
            .WithOrigins(appSettings.CorsOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());

        app.UseHttpsRedirection();

        ConfigureAdditional(app, env);

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    public abstract void ConfigureAdditional(IApplicationBuilder app, IWebHostEnvironment env);

    public virtual void ConfigureContainer(IServiceContainer container)
    {
        container.RegisterClassToInterface(GetAssembliesWithPrefix(StartProjectsName));
    }

    private static void ConfigureMapster()
    {
        TypeAdapterConfig.GlobalSettings.Scan(GetAssembliesWithPrefix(StartProjectsName));
        TypeAdapterConfig.GlobalSettings.Compile();
    }

    private static Assembly[] GetAssembliesWithPrefix(string startProjectsName) =>
        AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(assembly => assembly.FullName?.StartsWith(startProjectsName) == true)
            .ToArray();
}
namespace Education.WebApi;

public class AppSettings
{
    public string? AppName { get; set; }
    public Dictionary<string, string>? ConnectionStrings { get; set; }
    public string[] CorsOrigins { get; set; } = Array.Empty<string>();

    public string? GetConnectionString(string name)
        => ConnectionStrings?[name];
}
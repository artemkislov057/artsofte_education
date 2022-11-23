namespace Education.WebApi;

public sealed class ConnectionStrings
{
    public string EducationDb { get; set; } = null!;
}

public class AppSettings
{
    public string? AppName { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; } = new();
    public string[] CorsOrigins { get; set; } = Array.Empty<string>();
}
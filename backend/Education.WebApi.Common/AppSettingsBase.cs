namespace Education.WebApi.Common;

public class ConnectionStringsBase
{
    public string EducationDb { get; set; } = null!;
}

public class AppSettingsBase
{
    public string? AppName { get; set; }
    public ConnectionStringsBase ConnectionStrings { get; set; } = new();
    public string[] CorsOrigins { get; set; } = Array.Empty<string>();
}
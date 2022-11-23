using LightInject;

namespace Education.Extensions.LightInject;

public static class IServiceContainerExtensions
{
    public static IServiceContainer RegisterClassToInterface(this IServiceContainer source, string startProjectNames)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => assembly.FullName?.StartsWith(startProjectNames) == true);
        foreach (var assembly in assemblies)
        {
            source.RegisterAssembly(assembly, () => new PerRequestLifeTime(),
                (serviceType, implementationType) => serviceType.IsInterface);
        }

        return source;
    }
}
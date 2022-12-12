using System.Reflection;
using LightInject;

namespace Education.Extensions.LightInject;

public static class IServiceContainerExtensions
{
    public static IServiceContainer RegisterClassToInterface(this IServiceContainer source,
        IEnumerable<Assembly> assemblies)
    {
        foreach (var assembly in assemblies)
        {
            source.RegisterAssembly(assembly, () => new PerRequestLifeTime(),
                (serviceType, implementationType) => serviceType.IsInterface);
        }

        return source;
    }
}
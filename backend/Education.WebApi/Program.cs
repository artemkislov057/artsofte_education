using System.Reflection;
using LightInject.Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace Education.WebApi;

public static class Program
{
    private const string Education = "Education";
    
    public static void Main(string[] args)
    {
        LoadReferencesProjects(Assembly.GetExecutingAssembly());
        
        WebHost.CreateDefaultBuilder<Startup>(args)
            .UseLightInject()
            .Build()
            .Run();
    }
    
    private static void LoadReferencesProjects(Assembly assembly)
    {
        var assemblyNamesToLoad = GetEducationReferencesAssemblies(assembly);
        var assemblyNamesLoaded = new HashSet<AssemblyName>();
        while (assemblyNamesToLoad.Any())
        {
            var assemblyNamesNextToLoad = new List<AssemblyName>();
            foreach (var assemblyName in assemblyNamesToLoad.Where(assemblyName => !assemblyNamesLoaded.Contains(assemblyName)))
            {
                Assembly.Load(assemblyName);
                assemblyNamesLoaded.Add(assemblyName);
                var loadedAssembly = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .First(a => a.FullName == assemblyName.FullName);
                var referencesAssemblies = GetEducationReferencesAssemblies(loadedAssembly);
                assemblyNamesNextToLoad.AddRange(referencesAssemblies);
            }

            assemblyNamesToLoad = assemblyNamesNextToLoad;
        }
    }

    private static List<AssemblyName> GetEducationReferencesAssemblies(Assembly assembly) =>
        assembly.GetReferencedAssemblies()
            .Where(a => a.FullName.StartsWith(Education))
            .ToList();
}
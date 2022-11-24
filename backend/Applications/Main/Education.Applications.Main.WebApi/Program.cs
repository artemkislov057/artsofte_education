using System.Reflection;
using Education.Applications.Common;

namespace Education.Applications.Main.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        EntryPointBase<Startup>.EntryPoint(args, Assembly.GetExecutingAssembly());
    }
}
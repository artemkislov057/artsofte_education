using System.Reflection;
using Education.Applications.Common;

namespace Education.Applications.Admin.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        EntryPointBase<Startup>.EntryPoint(args, Assembly.GetExecutingAssembly());
    }
}
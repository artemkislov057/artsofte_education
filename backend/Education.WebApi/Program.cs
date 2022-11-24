using System.Reflection;
using Education.WebApi.Common;

namespace Education.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        EntryPointBase<Startup>.EntryPoint(args, Assembly.GetExecutingAssembly());
    }
}
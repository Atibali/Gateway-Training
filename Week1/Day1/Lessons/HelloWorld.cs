// .NET basics: what .NET is, the SDK, dotnet new, build and run, project structure, top-level statements
public static class HelloWorldLesson
{
    public static void Run(string[] args)
    {
        var name = args.Length > 0 ? args[0] : "World";
        Console.WriteLine(Greet(name));
    }

    private static string Greet(string who) => $"Hello, {who}!";
}
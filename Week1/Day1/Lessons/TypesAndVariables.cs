// Types and variables: value types, reference types, var, constants, nullable types
public static class TypesAndVariablesLesson
{
    public static void Run(string[] args)
    {
        var greetingName = args.Length > 0 ? args[0] : "World";
        Console.WriteLine(Greet(greetingName));

        int a = 5;
        int b = a;   // b gets a COPY of 5
        b = 10;      // a is still 5

        int[] x = { 1, 2 };
        int[] y = x; // y points to the SAME array
        y[0] = 99;   // x[0] is now 99 too

        int age = 30;              // explicit type
        var personName = "Alice";  // var -> inferred as string
        const double Pi = 3.14159;
        int? maybe = null;
        Console.WriteLine($"{age}, {personName}, {Pi}, {maybe?.ToString() ?? "null"}");

        Console.WriteLine(x[0] + " " + y[0]);

        object obj = 0;
        string kind = obj switch
        {
            int i when i > 0 => "positive integer",
            int => "integer",
            string text => "string",
            null => "null",
            _ => "other"
        };
        Console.WriteLine(kind);

        object o = "hello";
        if (o is string matchedText && matchedText.Length > 3)
        {
            Console.WriteLine(matchedText.ToUpper());
        }
    }

    private static string Greet(string who) => $"Hello, {who}!";
}
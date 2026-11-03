// Type conversion: implicit and explicit casting, Parse, TryParse, Convert
public static class TypeConversionLesson
{
    public static void Run(string[] args)
    {
        // Implicit conversion
        int sourceInt = 100;
        long implicitLong = sourceInt;
        double implicitDouble = sourceInt;

        // Explicit conversion
        double sourceDouble = 19.99;
        int explicitInt = (int)sourceDouble;

        long big = 5_000_000_000;
        int small = (int)big;
        Console.WriteLine($"{sourceInt} -> {implicitLong} -> {implicitDouble}");
        Console.WriteLine($"{sourceDouble} -> {explicitInt}; {big} -> {small}");

        object obj = 0;
        string kind = obj switch
        {
            int value when value > 0 => "positive integer",
            int => "integer",
            string matchedText => "string",
            null => "null",
            _ => "other"
        };
        Console.WriteLine(kind);

        object o = "hello";
        if (o is string text && text.Length > 3)
        {
            Console.WriteLine(text.ToUpper());
        }

        var ages = new Dictionary<string, int>();
        ages["Alice"] = 30;
        ages["Bob"] = 25;
        ages.Add("Charlie", 35);
        Console.WriteLine($"Alice's age: {ages["Alice"]}");
        Console.WriteLine(ages.ContainsKey("Alice"));
        Console.WriteLine(ages.TryGetValue("Carol", out int c));

        foreach (var kvp in ages)
            Console.WriteLine($"{kvp.Key} = {kvp.Value}");
    }
}

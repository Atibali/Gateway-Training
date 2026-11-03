// Methods: parameters and return values, overloading, optional and named parameters, ref and out, expression-bodied methods
public static class MethodsLesson
{
    public static void Run(string[] args)
    {
        Console.WriteLine(Add(3, 4));
        Console.WriteLine(Greet("Atib"));
        Console.WriteLine(IsOdd(5));

        Printer.PrintValue(42);
        Printer.PrintValue("Hello");
        Printer.PrintValue(10, 20);

        int a = 16;
        Increment(ref a);
        Console.WriteLine(a);

        int startValue = 10;
        Increment(startValue, out int incrementedValue);

        Console.WriteLine($"Original: {startValue}");
        Console.WriteLine($"Incremented: {incrementedValue}");

        int originalScore = 99;
        PrintScore(originalScore);

        Console.WriteLine(Sum(1, 2, 19, 12));
    }

    private static int Add(int x, int y) => x + y;

    private static string Greet(string name) => $"Hello, {name}!";

    private static bool IsOdd(int number) => number % 2 != 0;

    private static void Increment(ref int x) => x++;

    private static void Increment(int number, out int result) => result = number + 1;

    private static void PrintScore(in int score)
    {
        Console.WriteLine($"The safe, unmodified score is: {score}");
    }

    private static int Sum(params int[] numbers)
    {
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        return total;
    }

    private static class Printer
    {
        public static void PrintValue(int x) => Console.WriteLine(x);
        public static void PrintValue(string x) => Console.WriteLine(x);
        public static void PrintValue(int x, int y) => Console.WriteLine(x + y);
    }
}
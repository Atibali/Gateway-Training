// Operators: arithmetic, comparison, logical, ternary, null-coalescing (??) and null-conditional (?.)
public static class OperatorsLesson
{
    public static void Run(string[] args)
    {
        int a = 5;
        int b = a;   // b gets a COPY of 5
        b = 10;      // a is still 5

        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }

        string input = Console.ReadLine() ?? "";
        Console.WriteLine($"You entered: {input}");

        Console.WriteLine(Add(3, 4));
        Console.WriteLine(IsOdd(5));

        Console.WriteLine(Sum(1, 2, 19, 12));
    }

    private static int Add(int x, int y) => x + y;

    private static bool IsOdd(int number) => number % 2 != 0;

    private static int Sum(params int[] numbers)
    {
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        return total;
    }
}
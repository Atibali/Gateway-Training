// Control flow: if/else, switch statements and switch expressions, for, foreach, while, do-while, break and continue
public static class ControlFlowLesson
{
    public static void Run(string[] args)
    {
        string command = "123";
        switch (command)
        {
            case "Start":
                Console.WriteLine("Starting");
                break;
            case "Stop":
                Console.WriteLine("Stopping");
                break;
            default:
                Console.WriteLine("Unknown command");
                break;
        }

        Console.WriteLine(Describe(-5));
        Console.WriteLine(Describe(7));

        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }

        var names = new[] { "Jack", "Raj", "Varun", "Julia" };
        foreach (var name in names)
            Console.WriteLine(name);

        int score = 85;

        if (score >= 90)
            Console.WriteLine("A");
        else if (score >= 80)
            Console.WriteLine("B");
        else if (score >= 70)
            Console.WriteLine("C");
        else
            Console.WriteLine("F");
    }

    private static string Describe(int number) => number switch
    {
        < 0 => "negative",
        0 => "zero",
        1 or 2 or 3 => "small",
        < 10 => "medium",
        _ => "large"
    };
}
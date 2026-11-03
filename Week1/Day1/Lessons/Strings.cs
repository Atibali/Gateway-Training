// Strings: interpolation, common methods (Split, Substring, Trim, Contains, Replace), immutability, StringBuilder
public static class StringsLesson
{
    public static void Run(string[] args)
    {
        string s = "  Hello, World!  ";
        Console.WriteLine(s.Trim());
        Console.WriteLine(s.ToUpper());
        Console.WriteLine(s.Replace("World", "C#"));
        Console.WriteLine(s.Substring(2, 5));
        Console.WriteLine(s.Length);
        Console.WriteLine(s.Contains("Hello"));
        Console.WriteLine(s.StartsWith("  Hello"));
        Console.WriteLine(s.EndsWith("!  "));
        Console.WriteLine(s.IndexOf("World"));

        string name = "Atib";
        int age = 21;
        string msg = $"{name} is {age} years old";      // interpolation
        string msg2 = $"{name} is {age,5} years old";
        string msg3 = $"{Math.PI:F2}";

        Console.WriteLine(msg);
        Console.WriteLine(msg2);
        Console.WriteLine(msg3);

        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < 1000; i++)
            sb.Append(i).Append(',');
        string result = sb.ToString();
        Console.WriteLine(result);
    }
}
using System;

class DatesOperations
{
    static void Main()
    {
        DateTime today=DateTime.Today;

        Console.WriteLine("Today: "+today);
        Console.WriteLine("Tomorrow: "+today.AddDays(1));
        Console.WriteLine("Yesterday: "+today.AddDays(-1));
        Console.WriteLine("Next Month: "+today.AddMonths(1));
        Console.WriteLine("After 6 hours: "+DateTime.Now.AddHours(5));
    }
}
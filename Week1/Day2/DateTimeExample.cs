using System;

class DateTimeExample
{
    static void Main()
    {
        DateTime today = DateTime.Now;

        Console.WriteLine("Current Date and Time: " + today);
        Console.WriteLine("Date: "+today.ToShortDateString());
        Console.WriteLine("Time: "+today.ToShortTimeString());
        Console.WriteLine("Year: "+today.Year);
        Console.WriteLine("Month: "+today.Month);
        Console.WriteLine("Day: "+today.Day);
    }
}
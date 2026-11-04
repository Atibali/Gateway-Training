using System;

class TimeSpanExample
{
    static void Main()
    {
        DateTime start= new DateTime(2026,11,4,11,30,0);
        DateTime end= new DateTime(2026,11,4,17,40,0);
        TimeSpan duration=end-start;

        Console.WriteLine("Total Hours: "+duration.TotalHours);
        Console.WriteLine("Total Minutes: "+duration.TotalMinutes);
        Console.WriteLine("Duration: "+duration);
    }
}
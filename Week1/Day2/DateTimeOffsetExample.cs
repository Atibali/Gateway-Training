using System;

class DateTimeOffsetExample
{
    static void Main()
    {
        DateTime dt= DateTime.Now;

        DateTimeOffset dto=DateTimeOffset.Now;

        Console.WriteLine("DateTime: "+ dt);
        Console.WriteLine("DateTimeOffset: "+ dto);

        Console.WriteLine("UTC Offset: "+dto.Offset);
    }
}
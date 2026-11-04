using System;

class UTC
{
    static void Main()
    {
        DateTime localTime=DateTime.Now;
        DateTime utcTime=DateTime.UtcNow;

        Console.WriteLine("Local Time: "+ localTime);
        Console.WriteLine("UTC Time: "+utcTime);

        Console.WriteLine("Local Time Zone: "+TimeZoneInfo.Local.DisplayName);
    }
}
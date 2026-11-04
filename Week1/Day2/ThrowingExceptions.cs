using System;

class ThrowingExceptions
{
    static void Main()
    {
        try
        {
            int age=15;

            if(age<18)
            {
                throw new Exception("You are not Eligible to Vote.");
            }
            Console.WriteLine("You Can vote");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
        }
    }
}
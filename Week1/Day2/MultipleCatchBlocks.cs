using System;

class MultipleCatchBlocks
{
    static void Main()
    {
        try
        {
            Console.Write("Enter a Number: ");
            int num=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(100/num);
        }
        catch(FormatException)
        {
            Console.WriteLine("Enter a Valid Number next time");
        }
        catch(DivideByZeroException)
        {
            Console.WriteLine("Cannot Divide by Zero");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
        }
    }
}
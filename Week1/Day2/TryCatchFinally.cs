using System;

class TryCatchFinally
{
    static void Maain()
    {
        try
        {
            int a=10;
            int b=0;

            int result=a/b;
            Console.WriteLine("Result: "+ result);
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine("Error: "+ ex);

        }
        finally
        {
            Console.WriteLine("Finally Block Executed");
        }
    }
}
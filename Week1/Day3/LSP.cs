
using System;

// BAD APPROACH: Ostrich cannot satisfy Bird's Fly() behavior

public class Bird1
{
    public virtual void Fly()
    {
        Console.WriteLine("Bird is flying.");
    }
}

public class Sparrow1 : Bird1
{
    public override void Fly()
    {
        Console.WriteLine("Sparrow is flying.");
    }
}

public class Ostrich1 : Bird1
{
    public override void Fly()
    {
        throw new NotImplementedException(
            "Ostriches cannot fly!"
        );
    }
}

// GOOD APPROACH: Separate flying behavior

public class Bird2
{
    public void Eat()
    {
        Console.WriteLine("Bird is eating.");
    }
}

public interface IFlyable
{
    void Fly();
}

public class Sparrow2 : Bird2, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Sparrow is flying.");
    }
}

public class Ostrich2 : Bird2
{
    public void Run()
    {
        Console.WriteLine("Ostrich is running.");
    }
}

// Main Program

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== BAD APPROACH ===");

        Bird1 bird1 = new Sparrow1();
        bird1.Fly();

        Bird1 bird2 = new Ostrich1();

        try
        {
            bird2.Fly();
        }
        catch (NotImplementedException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine();

        Console.WriteLine("=== GOOD APPROACH (LSP) ===");

        Sparrow2 sparrow = new Sparrow2();
        Ostrich2 ostrich = new Ostrich2();

        sparrow.Eat();
        sparrow.Fly();

        ostrich.Eat();
        ostrich.Run();
    }
}

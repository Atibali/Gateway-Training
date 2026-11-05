new Counter();
new Counter();
Console.WriteLine(Counter.Count);
Counter.Reset();
Console.WriteLine(Counter.Count);
Console.WriteLine(MathHelper.Square(5));
public class Counter
{
    public static int Count{get; private set;}
    public int Id {get;}
    public Counter()
    {
        Count++;
        Id = Count;
    }
    public static void Reset()
    {
        Count = 0;
    }
}
public static class MathHelper
{
        public static int Square(int number)
        {
            return number * number;
        }
        public static int Cube(int number)
        {
            return number * number * number;
        }
    }
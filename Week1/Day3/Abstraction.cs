Rectangle r=new Rectangle(4,5);
r.Print();
((IsPrintable)r).Print();

public interface IShape
{
    double Area();
}
public interface IsPrintable
{
    void Print();
}
public abstract class Shape: IShape
{
    public abstract double Area();
    public virtual void Print()
    {
        Console.WriteLine($"Area: {Area():F2}");
    }
}
public class Rectangle : Shape, IsPrintable
{
    public double Width {get;}
    public double Height {get;}
    public Rectangle(double w,double h){Width=w;Height=h;}
    public override double Area()
    {
        return Width*Height;
    }
    void IsPrintable.Print()
    {
        Console.WriteLine($"Rectangle {Width}*{Height}");
    }
}
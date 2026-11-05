Shape[] shapes={new Circle(2),new Square(3)};
foreach(var s in shapes)
    Console.WriteLine(s.Area());
Base b= new Derived();
b.Show();
((Derived)b).Show();
public class Calculator
{
    // OverLoading
    public int Add(int a,int b)
    {
        return a + b;
    }
    public double Add(double a,double b)
    {
        return a + b;
    }
    public int Add(int a,int b,int c)
    {
        return a + b + c;
    }
}
public class Shape
{
    public virtual double Area()
    {
        return 0;
    }
}
public class Circle : Shape
{
    public double Radius {get; set;}
    public Circle(double r)
    {
        Radius=r;
    }
    public override double Area()
    {
        return Math.PI*Radius*Radius;
    }
}

public class Square : Shape
{
    public double Side {get; set;}
    public Square(double s)
    {
        Side=s;
    }
    public override double Area()
    {
        return Side*Side;
    }
}

public class Base
{
    public void Show()
    {
        Console.WriteLine("Base.Show");
    }
}
public class Derived : Base
{
    public new void Show()
    {
        Console.WriteLine("Derived.show");
    }
}
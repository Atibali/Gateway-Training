// Open/Closed Principle (OCP)

var price = 100m;
var noDiscount = new NoDiscount();
var tenPercentDiscount = new TenPercentDiscount();
Console.WriteLine(noDiscount.Apply(price));
Console.WriteLine(tenPercentDiscount.Apply(price));

public abstract class Discount
{
    public abstract decimal Apply(decimal price);
}
public class NoDiscount : Discount
{
    public override decimal Apply(decimal price)
    {
        return price;
    }
}
public class TenPercentDiscount : Discount
{
    public override decimal Apply(decimal price)
    {
        return price * 0.9m;
    }
}
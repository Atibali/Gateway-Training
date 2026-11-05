Vehicle c = new Car("Toyota");
Vehicle b = new Bike("Yamaha");
c.Drive(); // Toyota car is driving on road.
b.Drive(); // Yamaha bike is driving on track.
public class Vehicle
{
    public string Brand {get; set;}
    public Vehicle(string brand)
    {
        Brand=brand
    }
    public virtual void Drive() => Console.WriteLine($"{Brand} is driving.");
}

public class Car : Vehicle
{
    public Car(string brand) : base(brand) {}
    public override  void Drive()
    {
        Console.WriteLine($"{Brand} car is driving on road.");
    }
}
public class Bike : Vehicle
{
    public Bike(string brand) : base(brand) { }
    public override void Drive()
    {
        Console.WriteLine($"{Brand} bike is driving on track.");
    }
}
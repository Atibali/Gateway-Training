var v = new AmphibiousVehicle("TriAthlon");
v.Fly();
v.Swim();
v.Drive();

public interface IFlyable
{
    void Fly();
}
public interface ISwimmable
{
    void Swim();
}
public interface IDrivable
{
    void Drive();
}
public class AmphibiousVehicle : IFlyable, ISwimmable, IDrivable
{
    public string Name { get; }
    public AmphibiousVehicle(string name) => Name = name;

    public void Fly()
    {
        Console.WriteLine($"{Name} is flying.");
    }
    public void Swim(){
        Console.WriteLine($"{Name} is swimming.");
    }
    public void Drive() {
        Console.WriteLine($"{Name} is driving.");
    }
}

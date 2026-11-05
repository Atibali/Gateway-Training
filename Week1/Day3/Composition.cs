new Bird(new CanFly()).Fly();
new Bird(new CannotFly()).Fly();
public class BirdSample
{
    public void Fly()
    {
        Console.WriteLine("Flying");
    }
}
public class Penguin :  BirdSample {
    // Example pengiun cannot fly but will always inherity fly() method
}

// Use Instead Composition for like this behaviours
public interface IFlyBehaviour{
    void Fly();
}
public class CanFly : IFlyBehaviour {
    public void Fly()
    {
        Console.WriteLine("Flying");
    }
}
public class CannotFly : IFlyBehaviour {
    public void Fly()
    {
        Console.WriteLine("Cannot Fly");
    }
}
public class Bird
{
    private readonly IFlyBehaviour _flyBheaviour;
    public Bird(IFlyBehaviour fb)
    {
       _flyBheaviour=fb; 
    }
    public void Fly()
    {
        _flyBheaviour.Fly();
    }
}
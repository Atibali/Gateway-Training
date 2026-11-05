var obj=new Cat();
obj.Eat();
obj.Play();
public class Animal { public virtual void Eat() => Console.WriteLine("Animal eats"); }

public interface IPet { void Play(); }

public class Cat : Animal, IPet
{
    public override void Eat() => Console.WriteLine("Cat eats fish");
    public void Play() => Console.WriteLine("Cat plays with yarn");
}
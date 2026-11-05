var dog=new Dog();
dog.Breathe();
dog.Eat();
dog.Bark();
public class LivingBeing
{
    public void Breathe()
    {
        Console.WriteLine("Breathing...");
    }
}
public class Animal : LivingBeing
{
    public void  Eat()
    {
        Console.WriteLine("Eating");
    }
}
public class Dog : Animal {
    public void Bark()
    {
        Console.WriteLine("Barking");
    }
}
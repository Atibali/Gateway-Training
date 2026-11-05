Animal a=new Dog("Buddy","Golden Retriever");
a.Speak();
public class Animal{
    public string Name {get;}
    public Animal(string name)=> Name=name;
    public virtual void Speak()=> Console.WriteLine("Animal Sound");
}
public class Dog:Animal{
    public string Breed {get;}
    public Dog(string name, string breed):base(name)=> Breed=breed;
    public override void Speak()
    {
        Console.WriteLine($"{Name} {Breed} barks: Woof");
    }
}
public sealed class Puppy:Dog{
    public Puppy(string name):base(name,"Puppy"){}
}
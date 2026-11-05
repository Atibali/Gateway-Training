Usage
var p1 = new Person("Ali", 30) { Id = 1 };
var p2 = new Person { Name = "Sara", Age = 25, Id = 2 }; Console.WriteLine(p1);
Console.WriteLine(p2);

public class Person
{
    // Field
    private string _name;

    // Auto-property
    public int Age { get; set; }

    // init-only property
    public int Id { get; init; }

    // Property with backing field
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    // Constructor
    public Person(string name, int age)
    {
        this._name = name;
        this.Age = age;
    }

    // Parameterless constructor
    public Person() : this("Unknown", 0) { }

    public override string ToString() => $"{Id}: {Name} ({Age})";
}

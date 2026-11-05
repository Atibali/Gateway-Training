// Interface Segregation Principle (ISP)
var worker = new Worker();
worker.Work();
worker.Eat();
var robot = new Robot();
robot.Work();
//Bad
public interface IWorker
{
    void Work();
    void Eat();
}

//Good
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}
public class Worker : IWorkable, IEatable
{
    public void Work()
    {
        Console.WriteLine("Worker is working.");
    }

    public void Eat()
    {
        Console.WriteLine("Worker is eating.");
    }
}
public class Robot : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Robot is working.");
    }
}
var s1= new PointStruct(1,2);
var s2=s1;
s2.X=77;
Console.WriteLine(s1.X); //value type remians unchanged

var c1= new PointClass(1,2);
var c2=c1;
c2.X=77;
Console.WriteLine(c1.X); //Reference type changes the original value

var p1= new PersonRecord("Atib",21);
var p2=p1 with {Age=22};
Console.WriteLine(p1);
Console.WriteLine(p1== new PersonRecord("Atib",31)); //false compare by value
Console.WriteLine(p1== new PersonRecord("Atib",21)); //true compare by value
Console.WriteLine(p1);


public struct PointStruct
{
    public int X, Y;
    public PointStruct(int x, int y) { X = x; Y = y; }
}
public class PointClass
{
    public int X, Y;
    public PointClass(int x, int y) { X = x; Y = y; }
}

public record PersonRecord(string Name, int Age);
public record struct PointRecord(int X, int Y);
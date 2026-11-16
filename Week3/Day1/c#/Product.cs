
using System;
using System.Collections.Generic;
using System.Linq;

// Product class
class ProductDemo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    public ProductDemo(int id, string name, decimal price, string category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }
}

class Program
{
    static void Main()
    {
        var products = new List<ProductDemo>
        {
            new(1, "Laptop", 1200m, "Electronics"),
            new(2, "Mouse", 25m, "Electronics"),
            new(3, "Desk", 300m, "Furniture"),
            new(4, "Chair", 150m, "Furniture"),
            new(5, "Monitor", 400m, "Electronics"),
        };

        // Query Syntax
        var expensiveQuery =
            from p in products
            where p.Price > 100
            orderby p.Price descending
            select p.Name;

        Console.WriteLine("Query Syntax Results:");

        foreach (var name in expensiveQuery)
        {
            Console.WriteLine(name);
        }

        // Method Syntax
        var expensiveMethod = products
            .Where(p => p.Price > 100)
            .OrderByDescending(p => p.Price)
            .Select(p => p.Name);

        Console.WriteLine("\nMethod Syntax Results:");

        foreach (var name in expensiveMethod)
        {
            Console.WriteLine(name);
        }
    }
}

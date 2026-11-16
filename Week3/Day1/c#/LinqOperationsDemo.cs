
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// Product Class
class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, decimal price, string category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }
}

// Category Class
class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
// Entity Interface
interface IEntity
{
    int Id { get; }
}

// Generic Repository
class Repository<T> where T : class, IEntity
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public T? GetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }
}

// Custom Delegate
delegate int MathOp(int a, int b);

class Program
{
    // Callback Method
    static void Process(
        List<int> nums,
        Func<int, bool> filter,
        Action<int> onEach)
    {
        foreach (var n in nums.Where(filter))
        {
            onEach(n);
        }
    }

    static async Task Main()
    {
        var products = new List<Product>
        {
            new(1, "Laptop", 1200m, "Electronics"),
            new(2, "Mouse", 25m, "Electronics"),
            new(3, "Desk", 300m, "Furniture"),
            new(4, "Chair", 150m, "Furniture"),
            new(5, "Monitor", 400m, "Electronics"),
            new(6, "Keyboard", 80m, "Accessories")
        };

        var categories = new List<Category>
        {
            new(1, "Electronics"),
            new(2, "Furniture")
        };

        // 1. WHERE - FILTER

        Console.WriteLine("\nWHERE: Electronics Products");

        var electronics = products
            .Where(p => p.Category == "Electronics");

        foreach (var p in electronics)
            Console.WriteLine($"{p.Name} - {p.Price:C}");

        // 2. SELECT - PROJECT / TRANSFORM

        Console.WriteLine("\nSELECT: Product Names");

        var names = products.Select(p => p.Name);

        foreach (var name in names)
            Console.WriteLine(name);


        Console.WriteLine("\nSELECT: Product DTOs");

        var dtos = products.Select(p => new
        {
            p.Id,
            p.Name,
            PriceWithTax = p.Price * 1.2m
        });

        foreach (var dto in dtos)
            Console.WriteLine($"{dto.Id} | {dto.Name} | {dto.PriceWithTax:C}");


        // 3. ORDERBY / THENBY - SORTING

        Console.WriteLine("\nORDERBY: Category, THENBY: Price DESC");

        var sorted = products
            .OrderBy(p => p.Category)
            .ThenByDescending(p => p.Price);

        foreach (var p in sorted)
            Console.WriteLine($"{p.Category} | {p.Name} | {p.Price:C}");


        // 4. GROUPBY - GROUP DATA

        Console.WriteLine("\nProducts by Category");

        var byCategory = products
            .GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count(),
                Total = g.Sum(p => p.Price),
                Items = g.Select(p => p.Name).ToList()
            });

        foreach (var g in byCategory)
        {
            Console.WriteLine(
                $"{g.Category}: {g.Count} items, Total: {g.Total:C}");

            Console.WriteLine("Products: " + string.Join(", ", g.Items));
        }

        // 5. JOIN - INNER JOIN

        Console.WriteLine("\nJOIN: Products with Categories");

        var joined = products.Join(
            categories,
            p => p.Category,
            c => c.Name,
            (p, c) => new
            {
                p.Name,
                CategoryId = c.Id,
                p.Price
            });

        foreach (var item in joined)
        {
            Console.WriteLine(
                $"{item.Name} | Category ID: {item.CategoryId} | {item.Price:C}");
        }


        // 6. LEFT JOIN - INCLUDE UNMATCHED ITEMS

        Console.WriteLine("\nLEFT JOIN: All Products");

        var leftJoin =
            from p in products
            join c in categories
                on p.Category equals c.Name into gj
            from c in gj.DefaultIfEmpty()
            select new
            {
                p.Name,
                Category = c?.Name ?? "None"
            };

        foreach (var item in leftJoin)
        {
            Console.WriteLine($"{item.Name} | Category: {item.Category}");
        }


        // 7. ANY AND ALL

        Console.WriteLine("\nANY AND ALl");

        bool hasExpensive = products.Any(p => p.Price > 1000);
        bool allPositive = products.All(p => p.Price > 0);
        bool anyFurniture = products.Any(p => p.Category == "Furniture");

        bool isEmpty = !products.Any();

        Console.WriteLine($"Has Expensive Product: {hasExpensive}");
        Console.WriteLine($"All Prices Positive: {allPositive}");
        Console.WriteLine($"Any Furniture: {anyFurniture}");
        Console.WriteLine($"Is Empty: {isEmpty}");


        // 8. FIRST VS SINGLE

        Console.WriteLine("\nFIRST VS SINGLE");

        // First: Returns first matching element
        var firstCheap = products.First(p => p.Price < 100);
        Console.WriteLine($"First Cheap Product: {firstCheap.Name}");

        // FirstOrDefault: Returns null if not found
        var maybe = products.FirstOrDefault(p => p.Price > 5000);
        Console.WriteLine($"Expensive Product: {maybe?.Name ?? "Not Found"}");

        // Single: Exactly one matching element
        var byId = products.Single(p => p.Id == 3);
        Console.WriteLine($"Product by ID: {byId.Name}");

        // SingleOrDefault: Zero or one matching element
        var unique = products.SingleOrDefault(p => p.Id == 99);
        Console.WriteLine($"Product ID 99: {unique?.Name ?? "Not Found"}");

        // Single throws exception if multiple matches
        try
        {
            var bad = products.Single(p => p.Category == "Electronics");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Multiple matches: " + ex.Message);
        }

        // ASYNC PROGRAMMING

        Console.WriteLine("\nASYNC PROGRAMMING");

        // Task<T> - asynchronous operation returning a value
        var asyncProduct = await GetProductAsync(products, 1);

        Console.WriteLine($"Async Product: {asyncProduct?.Name}");

        // Task.WhenAll - run multiple async operations concurrently
        int[] ids = { 1, 3, 5 };

        var tasks = ids
            .Select(id => GetProductAsync(products, id))
            .ToList();

        var results = await Task.WhenAll(tasks);

        Console.WriteLine("\nConcurrent Product Results:");

        foreach (var p in results)
        {
            Console.WriteLine(p?.Name ?? "Not Found");
        }

        // CancellationToken demonstration
        Console.WriteLine("\nCancellation Example:");

        using var cts = new CancellationTokenSource();

        cts.CancelAfter(250);

        await ProcessAsync(cts.Token);

        // GENERICS

        Console.WriteLine("\nGENERICS");

        var repository = new Repository<Product>();

        repository.Add(products[0]);
        repository.Add(products[1]);

        var foundProduct = repository.GetById(1);

        Console.WriteLine($"Repository Product: {foundProduct?.Name}");

        // DELEGATES AND LAMBDAS
        
        Console.WriteLine("\nDELEGATES AND LAMBDAS");

        // Custom Delegate
        MathOp add = (a, b) => a + b;
        MathOp mul = (a, b) => a * b;

        Console.WriteLine($"Addition: {add(2, 3)}");
        Console.WriteLine($"Multiplication: {mul(2, 3)}");

        // Func
        Func<int, bool> isEven = n => n % 2 == 0;

        // Action
        Action<string> log = msg =>
            Console.WriteLine($"[LOG] {msg}");

        log("Learning C# Delegates");

        Console.WriteLine($"Is 4 Even? {isEven(4)}");

        // Delegates as callbacks
        Process(
            new List<int> { 1, 2, 3, 4 },
            isEven,
            n => Console.WriteLine($"Even Number: {n}")
        );

    }
    // Async method returning Product
static async Task<Product?> GetProductAsync(
    List<Product> products,
    int id,
    CancellationToken ct = default)
{
    await Task.Delay(100, ct);

    return products.FirstOrDefault(p => p.Id == id);
}

// Async method with CancellationToken
static async Task ProcessAsync(CancellationToken ct)
{
    try
    {
        for (int i = 0; i < 100; i++)
        {
            ct.ThrowIfCancellationRequested();

            await Task.Delay(100, ct);

            Console.WriteLine($"Step {i}");
        }
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Cancelled gracefully.");
    }
}
}
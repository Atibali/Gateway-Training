// Collections: arrays, List<T>, Dictionary<TKey, TValue>, HashSet<T>, looping over collections
public static class CollectionsLesson
{
    public static void Run(string[] args)
    {
        int[] x = { 1, 2 };
        int[] y = x; // y points to the SAME array
        y[0] = 99;   // x[0] is now 99 too

        Console.WriteLine(x[0] + " " + y[0]);

        var arrayNames = new[] { "Jack", "Raj", "Varun", "Julia" };
        foreach (var name in arrayNames)
            Console.WriteLine(name);

        var names = new List<string>();
        names.Add("Alice");
        names.Add("Bob");
        names.AddRange(new[] { "Charlie", "Diana" });
        Console.WriteLine($"Count: {names.Count}");
        names.Remove("Bob");
        Console.WriteLine($"Count: {names.Count}");
        Console.WriteLine($"Contains Alice: {names.Contains("Alice")}");

        foreach (var n in names)
            Console.WriteLine(n);

        var aNames = names.Where(n => n.StartsWith("A")).ToList();
        var sorted = names.OrderBy(n => n).ToList();

        Console.WriteLine(aNames.Count);
        Console.WriteLine(sorted.Count);

        var ages = new Dictionary<string, int>();
        ages["Alice"] = 30;
        ages["Bob"] = 25;
        ages.Add("Charlie", 35);
        Console.WriteLine($"Alice's age: {ages["Alice"]}");
        Console.WriteLine(ages.ContainsKey("Alice"));
        Console.WriteLine(ages.TryGetValue("Carol", out int c));

        foreach (var kvp in ages)
            Console.WriteLine($"{kvp.Key} = {kvp.Value}");

        HashSet<string> fruits = new HashSet<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Apple"); // Duplicate, won't be added
        fruits.Add("Cherry");
        fruits.Add("Melon");

        Console.WriteLine($"Count: {fruits.Count}");
        Console.WriteLine($"Contains Banana? {fruits.Contains("Banana")}");
        fruits.Remove("Banana");
        Console.WriteLine($"Contains Banana? {fruits.Contains("Banana")}");

        Console.WriteLine("\nFruits:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine($" - {fruit}");
        }

        HashSet<int> setA = [1, 2, 3, 4];
        HashSet<int> setB = [3, 4, 5, 6];

        HashSet<int> union = new(setA);
        union.UnionWith(setB);
        Console.WriteLine($"\nUnion: {string.Join(", ", union)}");

        HashSet<int> intersect = new(setA);
        intersect.IntersectWith(setB);
        Console.WriteLine($"Intersect: {string.Join(", ", intersect)}");

        HashSet<int> except = new(setA);
        except.ExceptWith(setB);
        Console.WriteLine($"Except: {string.Join(", ", except)}");
    }
}
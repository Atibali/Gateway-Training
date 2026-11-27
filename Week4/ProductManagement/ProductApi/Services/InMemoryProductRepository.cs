using ProductApi.Models;

namespace ProductApi.Services;

public sealed class InMemoryProductRepository : IProductRepository
{
    private readonly object _lock = new();
    private readonly List<Product> _products =
    [
        new Product { Id = 1, Name = "Laptop", Price = 55000, Stock = 10 },
        new Product { Id = 2, Name = "Mouse", Price = 800, Stock = 25 },
        new Product { Id = 3, Name = "Keyboard", Price = 1500, Stock = 15 }
    ];

    public IReadOnlyList<Product> GetAll()
    {
        lock (_lock)
        {
            return _products.Select(Clone).ToArray();
        }
    }

    public Product? GetById(int id)
    {
        lock (_lock)
        {
            var product = _products.FirstOrDefault(product => product.Id == id);
            return product is null ? null : Clone(product);
        }
    }

    public Product Add(Product product)
    {
        lock (_lock)
        {
            EnsureUniqueName(product.Name, null);
            var created = Clone(product);
            created.Id = _products.Count == 0 ? 1 : _products.Max(item => item.Id) + 1;
            _products.Add(created);
            return Clone(created);
        }
    }

    public Product? Update(int id, Product product)
    {
        lock (_lock)
        {
            var index = _products.FindIndex(item => item.Id == id);
            if (index < 0)
                return null;

            EnsureUniqueName(product.Name, id);
            var updated = Clone(product);
            updated.Id = id;
            _products[index] = updated;
            return Clone(updated);
        }
    }

    public bool Delete(int id)
    {
        lock (_lock)
        {
            var index = _products.FindIndex(item => item.Id == id);
            if (index < 0)
                return false;

            _products.RemoveAt(index);
            return true;
        }
    }

    private void EnsureUniqueName(string name, int? excludedId)
    {
        if (_products.Any(item =>
                item.Id != excludedId &&
                string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase)))
        {
            throw new DuplicateProductNameException();
        }
    }

    private static Product Clone(Product product)
    {
        return new Product
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}

public sealed class DuplicateProductNameException : Exception
{
}

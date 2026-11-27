using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();
    Product? GetById(int id);
    Product Add(Product product);
    Product? Update(int id, Product product);
    bool Delete(int id);
}
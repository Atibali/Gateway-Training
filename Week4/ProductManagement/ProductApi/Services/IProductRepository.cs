using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductRepository
{
    Product? GetById(int id);
    Product Add(Product product);
}
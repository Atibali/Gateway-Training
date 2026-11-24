using ProductApi.Models;

namespace ProductApi.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public Product AddProduct(Product product)
    {
        if (product.Price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        return _repository.Add(product);
    }

    public Product? GetProduct(int id)
    {
        return _repository.GetById(id);
    }
}
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

    public IReadOnlyList<Product> GetProducts()
    {
        return _repository.GetAll();
    }

    public Product? GetProduct(int id)
    {
        return _repository.GetById(id);
    }

    public Product? UpdateProduct(int id, Product product)
    {
        if (product.Price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        return _repository.Update(id, product);
    }

    public bool DeleteProduct(int id)
    {
        return _repository.Delete(id);
    }
}
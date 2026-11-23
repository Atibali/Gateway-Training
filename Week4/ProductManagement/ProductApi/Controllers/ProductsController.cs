using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<Product> products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 55000,
            Stock = 10
        },
        new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 800,
            Stock = 25
        },
        new Product
        {
            Id = 3,
            Name = "Keyboard",
            Price = 1500,
            Stock = 15
        }
    };

    // GET: api/products
    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        return Ok(products);
    }

    // GET: api/products/1
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        product.Id = products.Max(p => p.Id) + 1;

        products.Add(product);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            product
        );
    }
}
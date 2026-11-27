using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    // GET: api/products
    [Authorize(Roles = "ProductReader,ProductWriter")]
    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        return Ok(_service.GetProducts());
    }

    // GET: api/products/1
    [Authorize(Roles = "ProductReader,ProductWriter")]
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _service.GetProduct(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // POST: api/products
    [Authorize(Roles = "ProductWriter")]
    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        try
        {
            var created = _service.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, created);
        }
        catch (DuplicateProductNameException)
        {
            return Conflict();
        }
    }

    // PUT: api/products/1
    [Authorize(Roles = "ProductWriter")]
    [HttpPut("{id}")]
    public ActionResult<Product> UpdateProduct(int id, Product product)
    {
        try
        {
            var updated = _service.UpdateProduct(id, product);
            return updated is null ? NotFound() : Ok(updated);
        }
        catch (DuplicateProductNameException)
        {
            return Conflict();
        }
    }

    // DELETE: api/products/1
    [Authorize(Roles = "ProductWriter")]
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        return _service.DeleteProduct(id) ? NoContent() : NotFound();
    }
}
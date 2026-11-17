
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = product.Id },
                product
            );
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return Ok("Product Deleted Successfully");
        }
    }
}

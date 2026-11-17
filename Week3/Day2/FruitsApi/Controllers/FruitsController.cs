using Microsoft.AspNetCore.Mvc;
using FruitsApi.Models;

namespace FruitsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        // Hardcoded fruit data
        private static List<Fruit> fruits = new List<Fruit>
        {
            new Fruit { Id = 1, Name = "Apple", Color = "Red", Price = 100 },
            new Fruit { Id = 2, Name = "Banana", Color = "Yellow", Price = 40 },
            new Fruit { Id = 3, Name = "Mango", Color = "Yellow", Price = 80 },
            new Fruit { Id = 4, Name = "Orange", Color = "Orange", Price = 60 },
            new Fruit { Id = 5, Name = "Grapes", Color = "Green", Price = 90 }
        };

        // GET: api/fruits
        [HttpGet]
        public IActionResult GetAllFruits()
        {
            return Ok(fruits);
        }

        // GET: api/fruits/1
        [HttpGet("{id}")]
        public IActionResult GetFruitById(int id)
        {
            var fruit = fruits.FirstOrDefault(f => f.Id == id);

            if (fruit == null)
            {
                return NotFound("Fruit not found");
            }

            return Ok(fruit);
        }
    }
}
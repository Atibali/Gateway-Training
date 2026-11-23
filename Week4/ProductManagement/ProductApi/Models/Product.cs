using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = "";

    [Range(1, 1000000)]
    public decimal Price { get; set; }

    [Range(0, 10000)]
    public int Stock { get; set; }
}
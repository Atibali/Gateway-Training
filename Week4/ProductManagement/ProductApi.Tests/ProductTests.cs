using Xunit;

namespace ProductApi.Tests;

[Trait("Shard", "2")]
public class ProductTests
{
    [Fact]
    public void Product_ShouldHaveCorrectName()
    {
        // Arrange
        var product = new ProductApi.Models.Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 50000,
            Stock = 5
        };

        // Act
        var result = product.Name;

        // Assert
        Assert.Equal("Laptop", result);
    }

    [Theory]
    [InlineData(100, 5, 500)]
    [InlineData(200, 3, 600)]
    [InlineData(50, 10, 500)]
    public void CalculateTotal_ShouldReturnCorrectAmount(
        decimal price, int quantity, decimal expected)
    {
        // Arrange & Act
        decimal total = price * quantity;

        // Assert
        Assert.Equal(expected, total);
    }
}
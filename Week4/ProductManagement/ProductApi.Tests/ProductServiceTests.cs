using Moq;
using Xunit;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Tests;

public class ProductServiceTests
{
    [Fact]
    public void AddProduct_ValidProduct_CallsRepository()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();

        var product = new Product
        {
            Name = "Laptop",
            Price = 50000,
            Stock = 5
        };

        mockRepo.Setup(repo => repo.Add(product))
                .Returns(product);

        var service = new ProductService(mockRepo.Object);

        // Act
        var result = service.AddProduct(product);

        // Assert
        Assert.Equal("Laptop", result.Name);

        mockRepo.Verify(
            repo => repo.Add(product),
            Times.Once
        );
    }

    [Fact]
    public void AddProduct_InvalidPrice_ThrowsException()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();

        var product = new Product
        {
            Name = "Laptop",
            Price = -10,
            Stock = 5
        };

        var service = new ProductService(mockRepo.Object);

        // Act & Assert
        Assert.Throws<ArgumentException>(
            () => service.AddProduct(product)
        );

        mockRepo.Verify(
            repo => repo.Add(It.IsAny<Product>()),
            Times.Never
        );
    }
}
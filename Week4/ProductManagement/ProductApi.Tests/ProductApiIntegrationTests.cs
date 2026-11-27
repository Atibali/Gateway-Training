using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using ProductApi.Models;

namespace ProductApi.Tests;

[Trait("Shard", "1")]
public class ProductApiIntegrationTests : IClassFixture<ProductApiFactory>
{
    private readonly HttpClient _anonymousClient;
    private readonly HttpClient _readerClient;
    private readonly HttpClient _writerClient;

    public ProductApiIntegrationTests(ProductApiFactory factory)
    {
        _anonymousClient = factory.CreateClient();
        _readerClient = factory.CreateClient();
        _readerClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "test-reader-key");
        _writerClient = factory.CreateClient();
        _writerClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "test-writer-key");
    }

    [Fact]
    public async Task CrudFlow_CreatesReadsUpdatesAndDeletesProduct()
    {
        var product = NewProduct($"crud-{Guid.NewGuid():N}");

        var createResponse = await _writerClient.PostAsJsonAsync("/api/products", product);

        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
        var created = await createResponse.Content.ReadFromJsonAsync<Product>();
        Assert.NotNull(created);
        Assert.True(created.Id > 0);
        Assert.Equal(product.Name, created.Name);

        var readResponse = await _writerClient.GetAsync($"/api/products/{created.Id}");
        Assert.Equal(HttpStatusCode.OK, readResponse.StatusCode);
        var readProduct = await readResponse.Content.ReadFromJsonAsync<Product>();
        Assert.NotNull(readProduct);
        Assert.Equal(created.Id, readProduct.Id);

        var updatedInput = NewProduct($"updated-{Guid.NewGuid():N}");
        var updateResponse = await _writerClient.PutAsJsonAsync(
            $"/api/products/{created.Id}",
            updatedInput);
        Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);
        var updated = await updateResponse.Content.ReadFromJsonAsync<Product>();
        Assert.NotNull(updated);
        Assert.Equal(updatedInput.Name, updated.Name);
        Assert.Equal(created.Id, updated.Id);

        var deleteResponse = await _writerClient.DeleteAsync($"/api/products/{created.Id}");
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        Assert.Equal(
            HttpStatusCode.NotFound,
            (await _writerClient.GetAsync($"/api/products/{created.Id}")).StatusCode);
    }

    [Fact]
    public async Task GetProducts_WithoutCredentialsReturnsUnauthorized()
    {
        var response = await _anonymousClient.GetAsync("/api/products");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task CreateProduct_WithReaderRoleReturnsForbidden()
    {
        var response = await _readerClient.PostAsJsonAsync(
            "/api/products",
            NewProduct($"reader-{Guid.NewGuid():N}"));

        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task GetMissingProduct_ReturnsNotFound()
    {
        var response = await _writerClient.GetAsync($"/api/products/{int.MaxValue}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateProduct_WithDuplicateNameReturnsConflict()
    {
        var product = NewProduct($"duplicate-{Guid.NewGuid():N}");
        var firstResponse = await _writerClient.PostAsJsonAsync("/api/products", product);
        Assert.Equal(HttpStatusCode.Created, firstResponse.StatusCode);

        product.Name = product.Name.ToUpperInvariant();
        var duplicateResponse = await _writerClient.PostAsJsonAsync("/api/products", product);

        Assert.Equal(HttpStatusCode.Conflict, duplicateResponse.StatusCode);
    }

    private static Product NewProduct(string name)
    {
        return new Product { Name = name, Price = 100, Stock = 3 };
    }
}

public sealed class ProductApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((_, configuration) =>
        {
            configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Authentication:ApiKeys:ProductReader"] = "test-reader-key",
                ["Authentication:ApiKeys:ProductWriter"] = "test-writer-key"
            });
        });
    }
}

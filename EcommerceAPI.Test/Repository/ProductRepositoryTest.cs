using EcommerceAPI.Data;
using EcommerceAPI.Data.Enums;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Test.Repository
{
    public class ProductRepositoryTest
    {
        //creating a fake database for test
        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Products.CountAsync() <= 0)
            {
                User user1 = new()
                {
                    Name = "Admin",
                    Email = "AdminB@what.com",
                    Password = "Admin123",
                };
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Products.Add(
                        new Product()
                        {
                            Name = "Smartphone",
                            Description = "Latest model smartphone with advanced features.",
                            Price = 799.99,
                            Stock = 50,
                            Category = ProductCategory.Electronics,
                            Owner = user1
                        }
                    );
                    await databaseContext.SaveChangesAsync();
                }
            }

            return databaseContext;
        }

        [Fact]
        public async void ProductRepository_GetProduct_ReturnProduct()
        {
            int id = 1;
            var context = await GetDatabaseContext();
            var productRepository = new ProductRepository(context);

            var result = productRepository.GetProduct(id);

            result.Should().NotBeNull();
            result.Should().BeOfType<Product>();
        }

        [Fact]
        public async void ProductRepository_GetProductByCategory_ReturnProductsOrNull()
        {
            ProductCategory productCategory = ProductCategory.Electronics;
            ProductCategory productCategoryNull = ProductCategory.Hobbies;
            var context = await GetDatabaseContext();
            var productRepository = new ProductRepository(context);

            var result1 = productRepository.GetProduct(productCategory);
            var result2 = productRepository.GetProduct(productCategoryNull);

            result1.Should().NotBeNull();
            result1.Should().BeOfType<List<Product>>();
            result2.Should().BeNullOrEmpty();
        }
    }
}

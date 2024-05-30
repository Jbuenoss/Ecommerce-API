using EcommerceAPI.Data.Enums;
using EcommerceAPI.Models;

namespace EcommerceAPI.Data
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedData()
        {
            User user1 = new()
            {
                Name = "Admin",
                Email = "AdminB@what.com",
                Password = "Admin123",
            };

            if (!_dataContext.Users.Any())
            {
                User user2 = new()
                {
                    Name = "Admins",
                    Email = "AdminBs@what.com",
                    Password = "Admin123",
                };

                _dataContext.Users.AddRange(user1, user2);
                _dataContext.SaveChanges();
            }

            if(!_dataContext.Products.Any())
            {
                Product product1 = new()
                {
                    Name = "Smartphone",
                    Description = "Latest model smartphone with advanced features.",
                    Price = 799.99,
                    Stock = 50,
                    Category = ProductCategory.Electronics,
                    Owner = user1
                };

                Product product2 = new()
                {
                    Name = "Jeans",
                    Description = "Comfortable and stylish jeans.",
                    Price = 49.99,
                    Stock = 50,
                    Category = ProductCategory.Clothing,
                    Owner = user1
                };

                Product product3 = new()
                {
                    Name = "Science Fiction Novel",
                    Description = "A thrilling science fiction novel.",
                    Price = 19.99,
                    Stock = 50,
                    Category = ProductCategory.Books,
                    Owner = user1,
                };

                Product product4 = new()
                {
                    Name = "Gaming Laptop",
                    Description = "High performance gaming laptop.",
                    Price = 1299.99,
                    Stock = 30,
                    Category = ProductCategory.ComputersAndAccessories,
                    Owner = user1,
                };

                Product product5 = new()
                {
                    Name = "Drone",
                    Description = "Remote controlled drone with camera.",
                    Price = 499.99,
                    Stock = 35,
                    Category = ProductCategory.Hobbies,
                    Owner = user1,
                };

                _dataContext.Products.AddRange(product1, product2, product3, product4, product5);
                _dataContext.SaveChanges();
            }
        }
    }
}

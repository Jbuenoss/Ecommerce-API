using EcommerceAPI.Data;
using EcommerceAPI.Data.Enums;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product GetProduct(string Name)
        {
            return _context.Products.Where(p => p.Name == Name).FirstOrDefault();
        }

        public ICollection<Product> GetProduct(ProductCategory category)
        {
            return _context.Products.Where(p => p.Category == category).ToList();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }
    }
}

using EcommerceAPI.Data.Enums;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string Name);
        ICollection<Product> GetProduct(ProductCategory category);
    }
}

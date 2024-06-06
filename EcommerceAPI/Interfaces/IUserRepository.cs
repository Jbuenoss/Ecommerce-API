using EcommerceAPI.Models;
using EcommerceAPI.Dto;

namespace EcommerceAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetById(int id);
        ICollection<Product> GetProductByUser(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool SaveUser();
    }
}

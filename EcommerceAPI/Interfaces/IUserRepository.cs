using EcommerceAPI.Models;
using EcommerceAPI.Dto;

namespace EcommerceAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        bool ExistUserByEmail(string email);
        User GetById(int id);
        User GetByEmail(string email);
        ICollection<Product> GetProductByUser(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool SaveUser();
    }
}

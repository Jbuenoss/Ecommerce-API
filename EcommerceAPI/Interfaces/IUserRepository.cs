using EcommerceAPI.Models;
using EcommerceAPI.Dto;

namespace EcommerceAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetById(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool SaveUser();
    }
}

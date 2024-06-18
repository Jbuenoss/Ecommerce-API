using EcommerceAPI.Data;
using EcommerceAPI.Dto;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public User GetById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        public bool ExistUserByEmail(string email)
        {
            if (_context.Users.Where(a => a.Email == email).FirstOrDefault() == null)
                return false;
            return true;
        }

        public ICollection<Product> GetProductByUser(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).SelectMany(p => p.Products).ToList();
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);

            return SaveUser();
        }
        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            return SaveUser();
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.Where(a => a.Id == id).FirstOrDefault();
            _context.Users.Remove(user);

            return SaveUser();
        }
        public bool SaveUser()
        {
            return _context.SaveChanges() > 0;
        }

    }
}

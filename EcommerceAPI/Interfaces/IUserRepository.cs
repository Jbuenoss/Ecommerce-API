﻿using EcommerceAPI.Models;
using EcommerceAPI.Dto;

namespace EcommerceAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetById(int id);
    }
}
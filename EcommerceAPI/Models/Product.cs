﻿using EcommerceAPI.Data.Enums;

namespace EcommerceAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public ProductCategory Category { get; set; }
        public User Owner { get; set; }

    }
}

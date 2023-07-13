﻿using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Model.Context
{
    public class MySqlDataContext : DbContext
    {
        

        public MySqlDataContext(DbContextOptions<MySqlDataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
       

        
    }
}

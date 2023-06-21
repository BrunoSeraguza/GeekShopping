using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class MySqlDataContext : DbContext
    {
        public MySqlDataContext() { }

        public MySqlDataContext(DbContextOptions<MySqlDataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
       
    }
}

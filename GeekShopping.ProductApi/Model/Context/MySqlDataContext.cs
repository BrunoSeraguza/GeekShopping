using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class MySqlDataContext : DbContext
    {
        public MySqlDataContext() { }

        public MySqlDataContext(DbContextOptions<MySqlDataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        //adicionando produtos 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id= 2,
                Name= "name",
                Value= 49,
                Description= "description",
                ImageUrl= "E:\\Microservices\\Microservices-dotnet-bruno\\GeekShooping\\GeekShopping.ProductApi\\ShopImages\\10_milennium_falcon.jpg",
                CategoryName= "TShirt",

            });

        }
       
    }
}

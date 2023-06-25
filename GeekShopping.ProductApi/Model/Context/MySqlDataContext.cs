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
                ImageUrl= "GeekShopping.ProductApi\\ShopImages\\2_no_internet.jpg",
                CategoryName= "TShirt",

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Magic",
                Value = 99,
                Description = "Tcg Magic",
                ImageUrl = "GeekShopping.ProductApi\\ShopImages\\10_milennium_falcon.jpg",
                CategoryName = "Card Game",

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Warhammer",
                Value = 299,
                Description = "Jogo de tabuleiro",
                ImageUrl = "GeekShopping.ProductApi\\ShopImages\\9_neil.jpg",
                CategoryName = "Jogo de tabuleiro",

            });

        }
       
    }
}

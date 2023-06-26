using GeekShopping.web.Services;
using GeekShopping.web.Services.IServices;

namespace GeekShopping.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient<IProductService, ProductService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ServicesUrls:ProductAPI"])
            );


            var app = builder.Build();

            //builder.Services.AddHttpClient<IProductService, ProductService>( c =>
            //c.BaseAddress = new Uri(builder.Configuration["ServicesUrls : ProductAPI"])
            //);
            
           


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
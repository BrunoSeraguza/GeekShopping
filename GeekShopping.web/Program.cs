using GeekShopping.web.Services;
using GeekShopping.web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

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

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";



            }).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = builder.Configuration["ServicesUrls:IdentityServer"];
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClientId = "geek_shopping";
                options.ClientSecret = "My_Super_Secret";
                options.ResponseType = "code";
                options.ClaimActions.MapJsonKey("role", "role", "role");
                options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                options.TokenValidationParameters.NameClaimType = "name";
                options.TokenValidationParameters.RoleClaimType = "role";
                options.Scope.Add("geek_shopping");
                options.SaveTokens = true;
            }
                
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

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
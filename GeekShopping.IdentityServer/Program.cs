using Duende.IdentityServer.Services;
using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Initializer;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using GeekShopping.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace GeekShopping.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

     

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MySqlContext>()
                .AddDefaultTokenProviders();

            var build = builder.Services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;

            }).AddInMemoryIdentityResources
            (IdentityConfiguration.identityResources)
            .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
            .AddInMemoryClients
            (IdentityConfiguration.clients)
            .AddAspNetIdentity<ApplicationUser>();

            build.Services.AddScoped<IDbInitializer, DbInitializer>();
            build.Services.AddScoped<IProfileService, ProfileService>();
          

            build.AddDeveloperSigningCredential();
          


            builder.Services.AddControllersWithViews();

            

            builder.Services.AddDbContext<MySqlContext>(options =>
            options.UseMySql("server=localhost;initial catalog=geekshopping_IdentityServer;uid=root;",
              Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mysql")));

            var app = builder.Build();
            //using (var scope = app.Services.CreateScope())
            //{
            //    var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            //    initializer.Initialize();
            //}


            var initializer = app.Services.CreateScope().ServiceProvider.GetService<IDbInitializer>();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();

            initializer.Initialize();
        

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
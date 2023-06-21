using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container. MySql
//var connection = builder.Configuration["MySqlConnection:DataBaseMysql"];
//var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));
//builder.Services.AddDbContext<MySqlDataContext>(options => options.UseMySql(connection, serverVersion));

builder.Services.AddDbContext<MySqlDataContext>(options => options.UseMySql("server=localhost;initial catalog=geekshopping_productapi;uid=root;",
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mysql")));


//builder.Services.AddDbContext<DbDataContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

//builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DbDataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

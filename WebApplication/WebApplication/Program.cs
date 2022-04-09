using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApplication.Database;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OrderDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderDatabase")));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();

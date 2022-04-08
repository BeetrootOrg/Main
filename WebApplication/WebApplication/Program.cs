using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication.Database;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

//builder.Configuration.AddJsonFile("appsettings.json", optional: false);
//public void ConfigureServices(IServiceCollection services)
//{
//builder.Services.AddControllers();

builder.Services.AddDbContext<OrderDbContext>(
        options => options.UseSqlServer(("Server=AMIGA\\SQLEXPRESS;Database=OrderDB;Trusted_Connection=True;")));
//}
//builder.Services.AddDbContext<OrderDbContext>(sp => new SqlConnection("Server=AMIGA\\SQLEXPRESS;Database=OrderDB;Trusted_Connection=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using WebApplication.Database;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
//builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddDbContext<OrderDbContext2>(sp => new SqlConnection("Server=AMIGA\\SQLEXPRESS;Database=OrderDB;Trusted_Connection=True;"));

//builder.Services.AddDbContext<OrderDbContext2>(options =>
//             options.UseSqlServer(Configuration.GetConnectionString("Server=AMIGA\\SQLEXPRESS;Database=OrderDB;Trusted_Connection=True;")));



//builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection("Server=AMIGA\\SQLEXPRESS;Database=OrderDB;Trusted_Connection=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
//pattern: "{controller=Person}/{action=Index}/{id?}");
pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();

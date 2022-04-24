using Microsoft.EntityFrameworkCore;
using WebApplication.Database;
using WebApplication.Services;
using WebApplication.Services.Interfaces;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OrderDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderDatabase")));
builder.Services.AddTransient<IShowPdf, ShowPdf>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();

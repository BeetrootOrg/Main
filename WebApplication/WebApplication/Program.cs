using Microsoft.EntityFrameworkCore;
using WebApplication.Database;
using WebApplication.Services;
using WebApplication.Services.Interfaces;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OrderDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderDatabase")));
builder.Services.AddTransient<IPdfService, PdfService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
pattern: "{controller=Orders}/{action=Index}/{id?}");

app.Run();

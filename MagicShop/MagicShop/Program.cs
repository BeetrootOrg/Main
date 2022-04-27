using BLL.Repository.Implementation;
using BLL.Repository.Interfaces;
using BLL.Services.Implementation;
using BLL.Services.Interfaces;
using DLL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ArmoryDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<IWeaponRepository, WeaponRepository>();
builder.Services.AddTransient<IWeaponService, WeaponService>();
builder.Services.AddTransient<IArmorRepository, ArmorRepository>();
builder.Services.AddTransient<IArmorService, ArmorService>();
builder.Services.AddTransient<IAccessoriesRepository, AccessoriesRepository>();
builder.Services.AddTransient<IAccessoriesService, AccessoriesService>();
builder.Services.AddTransient<ISearchService, SearchService>();
builder.Services.AddTransient<ICartService, CartService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(ICrudService<,>), typeof(CrudService<,>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMemoryCache();

// установка конфигурации подключения
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/Account/Login");
                });
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
    }
});

app.UseRouting();

app.UseAuthentication();    // аутентификация
app.UseAuthorization();     // авторизация

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

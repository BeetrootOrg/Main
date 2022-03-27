using BLL.Repository.Implementation;
using BLL.Repository.Interfaces;
using BLL.Services.Implementation;
using BLL.Services.Interfaces;
using DLL.Context;
using MagicShop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ArmoryDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<IWeaponRepository, WeaponRepository>();
builder.Services.AddTransient<IWeaponService, WeaponService>();
builder.Services.AddTransient<IArmorRepository, ArmorRepository>();
builder.Services.AddTransient<IArmorService, ArmorService>();
builder.Services.AddTransient<IAccessoriesRepository, AccessoriesRepository>();
builder.Services.AddTransient<IAccessoriesService, AccessoriesService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository <>));
builder.Services.AddScoped(typeof(ICrudService<,>), typeof(CrudService <,>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDefaultIdentity<IdentityUser>(options => { 
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

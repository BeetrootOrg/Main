using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Services;
using static WebApplication.Services.WorkingWithCourt;
using static WebApplication.Services.WorkingWithStatement;
using static WebApplication.Services.WorkingWithUser;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(x => x.LowercaseUrls = true);
//builder.Services.AddMediatR(typeof(UserController).Assembly);

builder.Services.Configure<ConnectConfiguration>(builder.Configuration);
//builder.Services.AddTransient<IDbConnection>(sp =>
//{
//    var configuration = sp.GetRequiredService<IOptionsMonitor<ConnectConfiguration>>();
//    return new SqlConnection(configuration.CurrentValue.DbConnectionString);
//});

string connectionString = "Server=localhost;Database=DocumentsDB;Trusted_Connection=True;TrustServerCertificate=True";
builder.Services.AddTransient<IUserRepository, UserRepository>(provider => new UserRepository(connectionString));
builder.Services.AddTransient<ICourtRepository, CourtRepository>(provider => new CourtRepository(connectionString));
builder.Services.AddTransient<INewStatement, NewStatement>(provider => new NewStatement(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
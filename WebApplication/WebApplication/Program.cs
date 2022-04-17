using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebApplication.Services;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRouting(x => x.LowercaseUrls = true);



builder.Services.Configure<ConnectConfiguration>(builder.Configuration);

builder.Services.AddTransient<ICourtRepository, CourtRepository>(sp =>
{
    var configuration = sp.GetRequiredService<IOptionsMonitor<ConnectConfiguration>>();
    return new CourtRepository(configuration.CurrentValue.DbConnectionString);
});
builder.Services.AddTransient<IUserRepository, UserRepository>(sp =>
{
    var configuration = sp.GetRequiredService<IOptionsMonitor<ConnectConfiguration>>();
    return new UserRepository(configuration.CurrentValue.DbConnectionString);
});
builder.Services.AddTransient<INewStatement, NewStatement>(sp =>
{
    var configuration = sp.GetRequiredService<IOptionsMonitor<ConnectConfiguration>>();
    return new NewStatement(configuration.CurrentValue.DbConnectionString);
});

var app = builder.Build();

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
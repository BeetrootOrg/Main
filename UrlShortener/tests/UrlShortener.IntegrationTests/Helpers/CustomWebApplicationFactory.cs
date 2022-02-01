using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using UrlShortener.Database.Context;

namespace UrlShortener.IntegrationTests.Helpers
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<UrlDbContext>));
                services.Remove(descriptor);

                services.AddDbContext<UrlDbContext>(options =>
                {
                    options.UseInMemoryDatabase("UrlsdbContext");
                }, ServiceLifetime.Singleton);
            });
        }
    }
}

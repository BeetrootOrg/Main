using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Transactions;
using dotenv.net;
using Microsoft.Extensions.Configuration;
using UrlShortener.Database.Context;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace UrlShortener.IntegrationTests.Helpers
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                DotEnv.Load();

                var config = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .Build();

                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<UrlDbContext>));
                services.Remove(descriptor);

                var transaction = new CommittableTransaction(new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                });

                var connection = new SqlConnection(config.GetConnectionString("UrlsDb"));
                connection.Open();
                connection.EnlistTransaction(transaction);

                services.AddSingleton(transaction);
                services.AddSingleton(connection);

                services.AddDbContext<UrlDbContext>(options =>
                {
                    options.UseSqlServer(connection);
                }, ServiceLifetime.Singleton);
            });

        }
    }
}

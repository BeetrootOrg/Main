using System;
using System.Threading.Tasks;
using System.Transactions;
using Bogus;
using dotenv.net;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UrlShortener.Database.Context;
using UrlShortener.Database.Models;

namespace UrlShortener.UnitTests.Tests
{
    public class ShortUrlTestBase : IAsyncDisposable
    {
        protected const int HashLength = 15;

        protected readonly UrlDbContext UrlDbContext;

        protected readonly Faker Faker;
        protected readonly Faker<ShortUrl> ShortUrlFaker;

        private readonly SqlConnection _connection;
        private readonly CommittableTransaction _transaction;

        protected ShortUrlTestBase()
        {
            DotEnv.Load();

            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
            
            _transaction = new CommittableTransaction(new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            });

            _connection = new SqlConnection(config.GetConnectionString("UrlsDb"));
            _connection.Open();
            _connection.EnlistTransaction(_transaction);
            
            var options = new DbContextOptionsBuilder<UrlDbContext>()
                .UseSqlServer(_connection)
                .Options;

            UrlDbContext = new UrlDbContext(options);
            
            Faker = new Faker();
            ShortUrlFaker = new Faker<ShortUrl>()
                .RuleFor(x => x.Id, f => 0)
                .RuleFor(x => x.Hash, f => f.Random.String2(HashLength))
                .RuleFor(x => x.Url, f => f.Internet.Url())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past());
        }

        public async ValueTask DisposeAsync()
        {
            _transaction.Dispose();
            await _connection.DisposeAsync();
            await UrlDbContext.DisposeAsync();
        }
    }
}
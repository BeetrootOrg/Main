using System;
using Bogus;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Database.Context;
using UrlShortener.Database.Models;

namespace UrlShortener.UnitTests.Tests
{
    public class ShortUrlTestBase : IDisposable
    {
        protected const int HashLength = 15;

        protected readonly UrlDbContext UrlDbContext;

        protected readonly Faker Faker;
        protected readonly Faker<ShortUrl> ShortUrlFaker;

        protected ShortUrlTestBase()
        {
            var options = new DbContextOptionsBuilder<UrlDbContext>()
                .UseInMemoryDatabase("UrlsDbContext")
                .Options;

            UrlDbContext = new UrlDbContext(options);
            
            Faker = new Faker();
            ShortUrlFaker = new Faker<ShortUrl>()
                .RuleFor(x => x.Id, f => 0)
                .RuleFor(x => x.Hash, f => f.Random.String2(HashLength))
                .RuleFor(x => x.Url, f => f.Internet.Url())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past());
        }

        public void Dispose()
        {
            UrlDbContext.Dispose();
        }
    }
}
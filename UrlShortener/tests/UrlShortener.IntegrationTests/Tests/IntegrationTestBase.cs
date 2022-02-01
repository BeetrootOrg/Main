using System;
using System.Net.Http;
using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Api;
using UrlShortener.Database.Context;
using UrlShortener.Database.Models;
using UrlShortener.IntegrationTests.Helpers;

namespace UrlShortener.IntegrationTests.Tests
{
    public class IntegrationTestBase : IDisposable
    {
        protected const int HashLength = 15;

        protected readonly HttpClient Client;
        protected readonly UrlDbContext UrlDbContext;

        protected readonly Faker<ShortUrl> ShortUrlFaker;

        private readonly AsyncServiceScope _scope;

        protected IntegrationTestBase(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });

            _scope = factory.Services.CreateAsyncScope();
            UrlDbContext = _scope.ServiceProvider.GetRequiredService<UrlDbContext>();

            ShortUrlFaker = new Faker<ShortUrl>()
                .RuleFor(x => x.Id, f => 0)
                .RuleFor(x => x.Hash, f => f.Random.String2(HashLength))
                .RuleFor(x => x.Url, f => f.Internet.Url())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past());
        }
        
        public void Dispose()
        {
            Client?.Dispose();
            UrlDbContext?.Dispose();
            _scope.Dispose();
        }
    }
}
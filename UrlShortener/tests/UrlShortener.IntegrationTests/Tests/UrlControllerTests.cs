using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UrlShortener.Api;
using UrlShortener.Database.Context;
using UrlShortener.Database.Models;
using UrlShortener.IntegrationTests.Helpers;
using Xunit;

namespace UrlShortener.IntegrationTests.Tests
{
    public class UrlControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>, IAsyncDisposable
    {
        private const int HashLength = 15;

        private readonly HttpClient _client;
        private readonly AsyncServiceScope _scope;
        private readonly UrlDbContext _urlDbContext;

        private readonly Faker<ShortUrl> _shortUrlFaker;

        public UrlControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });

            _scope = factory.Services.CreateAsyncScope();
            _urlDbContext = _scope.ServiceProvider.GetRequiredService<UrlDbContext>();

            _shortUrlFaker = new Faker<ShortUrl>()
                .RuleFor(x => x.Id, f => f.IndexFaker)
                .RuleFor(x => x.Hash, f => f.Random.String2(HashLength))
                .RuleFor(x => x.Url, f => f.Internet.Url())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past());
        }

        [Fact]
        public async Task GetRouteByHashShouldReturnIt()
        {
            // Arrange
            var shortUrl = _shortUrlFaker.Generate();
            await _urlDbContext.AddAsync(shortUrl);
            await _urlDbContext.SaveChangesAsync();

            // Act
            var response = await _client.GetAsync($"api/v1/Url/{shortUrl.Hash}");

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.Redirect);
            response.Headers.Location.ShouldBe(new Uri(shortUrl.Url));
        }

        public async ValueTask DisposeAsync()
        {
            await _scope.DisposeAsync();
            await _urlDbContext.DisposeAsync();
        }
    }
}
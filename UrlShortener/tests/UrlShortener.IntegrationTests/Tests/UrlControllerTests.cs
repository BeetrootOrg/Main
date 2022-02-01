using Shouldly;
using System;
using System.Net;
using System.Threading.Tasks;
using UrlShortener.Api;
using UrlShortener.IntegrationTests.Helpers;
using Xunit;

namespace UrlShortener.IntegrationTests.Tests
{
    public class UrlControllerTests : IntegrationTestBase, IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public UrlControllerTests(CustomWebApplicationFactory<Startup> factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task GetRouteByHashShouldReturnIt()
        {
            // Arrange
            var shortUrl = ShortUrlFaker.Generate();
            await UrlDbContext.AddAsync(shortUrl);
            await UrlDbContext.SaveChangesAsync();

            // Act
            var response = await Client.GetAsync(GetUrlToGetFullPath(shortUrl.Hash));

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.Redirect);
            response.Headers.Location.ShouldBe(new Uri(shortUrl.Url));
        }
        
        [Fact]
        public async Task GetRouteByHashShouldReturnBadRequestIfHashIsLong()
        {
            // Arrange
            var shortUrl = ShortUrlFaker.Generate();
            await UrlDbContext.AddAsync(shortUrl);
            await UrlDbContext.SaveChangesAsync();

            // Act
            var response = await Client.GetAsync(GetUrlToGetFullPath(Faker.Random.String2(60)));

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        private static string GetUrlToGetFullPath(string hash) => $"api/v1/Url/{hash}";
    }
}
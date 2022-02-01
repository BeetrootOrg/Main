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
            var response = await Client.GetAsync($"api/v1/Url/{shortUrl.Hash}");

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.Redirect);
            response.Headers.Location.ShouldBe(new Uri(shortUrl.Url));
        }
    }
}
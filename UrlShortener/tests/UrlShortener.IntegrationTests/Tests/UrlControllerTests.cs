using Shouldly;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UrlShortener.Api;
using UrlShortener.Api.Models;
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
        public async Task GetRouteByHashShouldReturnNotFoundIfThereNoData()
        {
            // Arrange
            var hash = Faker.Random.String2(8);

            // Act
            var response = await Client.GetAsync(GetUrlToGetFullPath(hash));

            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);

            var strContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ErrorResponse>(strContent);
            
            result.Message.ShouldBe($"Url with hash '{hash}' not found");
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

        [Fact]
        public async Task CreateRouteShouldCreateIt()
        {
            // Arrange
            var url = Faker.Internet.Url();
            var request = new ShortenUrlRequest
            {
                Url = url
            };
            
            // Act
            var response = await Client.PutAsync(CreateRoutePath(),
                new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    System.Net.Mime.MediaTypeNames.Application.Json));
            
            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.Created);

            var strContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ShortenUrlResponse>(strContent);
            
            result.ShortUrl.ShouldStartWith(Config.CurrentValue.BaseAddress);
            result.ShortUrl.Length.ShouldBeGreaterThan(Config.CurrentValue.BaseAddress.Length);
        }
        
        [Fact]
        public async Task CreateRouteShouldReturnBadRequestForLongUrls()
        {
            // Arrange
            var url = $"http://{string.Join(string.Empty, Enumerable.Repeat('s', 300))}.com";
            var request = new ShortenUrlRequest
            {
                Url = url
            };
            
            // Act
            var response = await Client.PutAsync(CreateRoutePath(),
                new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    System.Net.Mime.MediaTypeNames.Application.Json));
            
            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task CreateRouteShouldReturnOkSecondTime()
        {
            // Arrange
            var url = Faker.Internet.Url();
            var request = new ShortenUrlRequest
            {
                Url = url
            };
            
            // Act
            var response1 = await Client.PutAsync(CreateRoutePath(),
                new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    System.Net.Mime.MediaTypeNames.Application.Json));
            
            var response2 = await Client.PutAsync(CreateRoutePath(),
                new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    System.Net.Mime.MediaTypeNames.Application.Json));
            
            // Assert
            response1.StatusCode.ShouldBe(HttpStatusCode.Created);
            response2.StatusCode.ShouldBe(HttpStatusCode.OK);

            var strContent1 = await response1.Content.ReadAsStringAsync();
            var result1 = JsonConvert.DeserializeObject<ShortenUrlResponse>(strContent1);
            
            var strContent2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<ShortenUrlResponse>(strContent2);
            
            result1.ShortUrl.ShouldBe(result2.ShortUrl);
        }

        [Fact]
        public async Task ItShouldBePossibleToUseNewlyCreatedLink()
        {
            // Arrange
            var url = Faker.Internet.Url();
            var request = new ShortenUrlRequest
            {
                Url = url
            };
            
            // Act
            var createResponse = await Client.PutAsync(CreateRoutePath(),
                new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    System.Net.Mime.MediaTypeNames.Application.Json));
            
            var strContent = await createResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ShortenUrlResponse>(strContent);

            var getResponse = await Client.GetAsync(result.ShortUrl);
            
            // Assert
            getResponse.StatusCode.ShouldBe(HttpStatusCode.Redirect);
            getResponse.Headers.Location.ShouldBe(new Uri(url));
        }

        private static string GetUrlToGetFullPath(string hash) => $"api/v1/Url/{hash}";
        private static string CreateRoutePath() => "api/v1/Url";
    }
}
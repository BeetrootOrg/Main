using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using UrlShortener.Domain.Queries;
using Xunit;

namespace UrlShortener.UnitTests.Tests
{
    [Collection(CollectionNames.DbQueries)]
    public class GetUrlQueryTests : ShortUrlTestBase
    {
        private readonly GetLongUrlQueryHandler _handler;

        public GetUrlQueryTests()
        {
            _handler = new GetLongUrlQueryHandler(new Mock<ILogger<GetLongUrlQueryHandler>>().Object,
                UrlDbContext);
        }
        
        [Fact]
        public async Task HandleShouldReturnUrlWhenItExists()
        {
            // Arrange
            var shortUrl = ShortUrlFaker.Generate();

            UrlDbContext.Urls.Add(shortUrl);
            await UrlDbContext.SaveChangesAsync();

            var query = new GetLongUrlQuery
            {
                Hash = shortUrl.Hash
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);
            
            // Assert
            result.ShouldNotBeNull();
            result.Result.ShouldBe(SearchUrlResult.Success);
            result.Url.ShouldBe(shortUrl.Url);
        }
        
        [Fact]
        public async Task HandleShouldReturnNotFoundResult()
        {
            // Arrange
            var query = new GetLongUrlQuery
            {
                Hash = Faker.Random.String2(HashLength)
            };
            
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);
            
            // Assert
            result.ShouldNotBeNull();
            result.Result.ShouldBe(SearchUrlResult.NotFound);
            result.Message.ShouldBe($"Url with hash '{query.Hash}' not found");
        }
    }
}
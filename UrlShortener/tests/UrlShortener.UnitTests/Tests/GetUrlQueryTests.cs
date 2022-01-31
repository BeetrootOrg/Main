using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using UrlShortener.Database.Context;
using UrlShortener.Database.Models;
using UrlShortener.Domain.Queries;
using Xunit;

namespace UrlShortener.UnitTests.Tests
{
    public class GetUrlQueryTests
    {
        private const int HashLength = 15;
        
        private readonly UrlDbContext _urlDbContext;

        private readonly Faker _faker;
        private readonly Faker<ShortUrl> _shortUrlFaker;

        private readonly GetLongUrlQueryHandler _handler;

        public GetUrlQueryTests()
        {
            var options = new DbContextOptionsBuilder<UrlDbContext>()
                .UseInMemoryDatabase("UrlDbContext")
                .Options;

            _urlDbContext = new UrlDbContext(options);
            
            _faker = new Faker();
            _shortUrlFaker = new Faker<ShortUrl>()
                .RuleFor(x => x.Id, f => f.IndexFaker)
                .RuleFor(x => x.Hash, f => f.Random.String2(HashLength))
                .RuleFor(x => x.Url, f => f.Internet.Url())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past());

            _handler = new GetLongUrlQueryHandler(new Mock<ILogger<GetLongUrlQueryHandler>>().Object,
                _urlDbContext);
        }
        
        [Fact]
        public async Task HandleShouldReturnUrlWhenItExists()
        {
            // Arrange
            var shortUrl = _shortUrlFaker.Generate();

            _urlDbContext.Urls.Add(shortUrl);
            await _urlDbContext.SaveChangesAsync();

            var query = new GetUrlQuery
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
            var query = new GetUrlQuery
            {
                Hash = _faker.Random.String2(HashLength)
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
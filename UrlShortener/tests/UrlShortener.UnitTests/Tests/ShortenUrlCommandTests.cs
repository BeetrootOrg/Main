using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using UrlShortener.Database.Models;
using UrlShortener.Domain.Commands;
using UrlShortener.Domain.Services.Interfaces;
using Xunit;

namespace UrlShortener.UnitTests.Tests
{
    [Collection(CollectionNames.DbQueries)]
    public class ShortenUrlCommandTests : ShortUrlTestBase
    {
        private readonly Mock<IHashGenerator> _hashGenerator;
        private readonly Mock<IDateTimeProvider> _dateTimeProvider;

        private readonly ShortenUrlCommandHandler _command;
        private readonly string _baseAddress;

        public ShortenUrlCommandTests()
        {
            _hashGenerator = new Mock<IHashGenerator>();
            _dateTimeProvider = new Mock<IDateTimeProvider>();

            _baseAddress = Faker.Internet.Url();

            _command = new ShortenUrlCommandHandler(new Mock<ILogger<ShortenUrlCommandHandler>>().Object,
                UrlDbContext,
                _hashGenerator.Object,
                _dateTimeProvider.Object,
                new ShortenUrlCommandHandlerConfig
                {
                    BaseAddress = _baseAddress
                });
        }

        [Fact]
        public async Task HandleShouldCreateNewLink()
        {
            // Arrange
            var expected = ShortUrlFaker.Generate();

            _hashGenerator.Setup(x => x.ToHash(It.Is<string>(str => str.Equals(expected.Url))))
                .Returns(expected.Hash);

            _dateTimeProvider.Setup(x => x.Now)
                .Returns(expected.CreatedAt);

            var command = new ShortenUrlCommand
            {
                Url = expected.Url
            };
            
            // Act
            var result = await _command.Handle(command, CancellationToken.None);
            
            // Assert
            result.ShouldNotBeNull();
            result.Url.ShouldBe($"{_baseAddress}/{expected.Hash}");
            result.Result.ShouldBe(ShortenUrlResult.Created);

            var any = await UrlDbContext.Urls.AnyAsync(VerifyPredicate(expected));
            any.ShouldBeTrue();
        }
        
        [Fact]
        public async Task HandleShouldReturnLinkIfItExists()
        {
            // Arrange
            var expected = ShortUrlFaker.Generate();
            await UrlDbContext.AddAsync(expected);
            await UrlDbContext.SaveChangesAsync();
            
            _hashGenerator.Setup(x => x.ToHash(It.Is<string>(str => str.Equals(expected.Url))))
                .Throws<Exception>();

            _dateTimeProvider.Setup(x => x.Now)
                .Throws<Exception>();

            var command = new ShortenUrlCommand
            {
                Url = expected.Url
            };
            
            // Act
            var result = await _command.Handle(command, CancellationToken.None);
            
            // Assert
            result.ShouldNotBeNull();
            result.Url.ShouldBe($"{_baseAddress}/{expected.Hash}");
            result.Result.ShouldBe(ShortenUrlResult.AlreadyExists);
        }

        private static Expression<Func<ShortUrl, bool>> VerifyPredicate(ShortUrl expected) => url =>
            url.Hash == expected.Hash &&
            url.Url == expected.Url &&
            url.CreatedAt == expected.CreatedAt;
    }
}
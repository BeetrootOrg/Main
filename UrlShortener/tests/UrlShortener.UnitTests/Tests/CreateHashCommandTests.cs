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
    public class CreateHashCommandTests : ShortUrlTestBase
    {
        private readonly Mock<IHashGenerator> _hashGenerator;
        private readonly Mock<IDateTimeProvider> _dateTimeProvider;

        private readonly CreateHashCommandHandler _command;

        public CreateHashCommandTests()
        {
            _hashGenerator = new Mock<IHashGenerator>();
            _dateTimeProvider = new Mock<IDateTimeProvider>();

            _command = new CreateHashCommandHandler(new Mock<ILogger<CreateHashCommandHandler>>().Object,
                UrlDbContext,
                _hashGenerator.Object,
                _dateTimeProvider.Object);
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

            var command = new CreateHashCommand
            {
                Url = expected.Url
            };
            
            // Act
            var result = await _command.Handle(command, CancellationToken.None);
            
            // Assert
            result.ShouldNotBeNull();
            result.Hash.ShouldBe(expected.Hash);

            var any = await UrlDbContext.Urls.AnyAsync(VerifyPredicate(expected));
            any.ShouldBeTrue();
        }

        private static Expression<Func<ShortUrl, bool>> VerifyPredicate(ShortUrl expected) => url =>
            url.Hash == expected.Hash &&
            url.Url == expected.Url &&
            url.CreatedAt == expected.CreatedAt;
    }
}
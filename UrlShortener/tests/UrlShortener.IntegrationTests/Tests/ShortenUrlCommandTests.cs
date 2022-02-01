using Bogus;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Database.Context;
using UrlShortener.Database.Models;
using UrlShortener.Domain.Commands;
using UrlShortener.Domain.Services.Interfaces;
using UrlShortener.IntegrationTests.Common;
using Xunit;

namespace UrlShortener.IntegrationTests.Tests
{
    [Collection(CollectionNames.DbQueries)]
    public class ShortenUrlCommandTests : IDisposable
    {
        private const int HashLength = 15;

        private readonly UrlDbContext _urlDbContext;
        private readonly Faker _faker;
        private readonly Faker<ShortUrl> _shortUrlFaker;

        private readonly Mock<IHashGenerator> _hashGenerator;
        private readonly Mock<IDateTimeProvider> _dateTimeProvider;

        private readonly ShortenUrlCommandHandler _command;
        private readonly string _baseAddress;

        private readonly IList<object> _additionallyTracked = new List<object>();

        public ShortenUrlCommandTests()
        {
            DotEnv.Load();

            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var options = new DbContextOptionsBuilder<UrlDbContext>()
                .UseSqlServer(config.GetConnectionString("UrlsDb"))
                .Options;

            _urlDbContext = new UrlDbContext(options);

            _faker = new Faker();
            _shortUrlFaker = new Faker<ShortUrl>()
                .RuleFor(x => x.Id, f => 0)
                .RuleFor(x => x.Hash, f => f.Random.String2(HashLength))
                .RuleFor(x => x.Url, f => f.Internet.Url())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past());

            _hashGenerator = new Mock<IHashGenerator>();
            _dateTimeProvider = new Mock<IDateTimeProvider>();

            _baseAddress = _faker.Internet.Url();

            _command = new ShortenUrlCommandHandler(new Mock<ILogger<ShortenUrlCommandHandler>>().Object,
                _urlDbContext,
                _hashGenerator.Object,
                _dateTimeProvider.Object,
                new ShortenUrlCommandHandlerConfig
                {
                    BaseAddress = _baseAddress
                });
        }

        [Fact]
        public async Task HandleShouldReturnAddedUrlIfUrlCreatedDuringRequest()
        {
            // Arrange
            var expected = _shortUrlFaker.Generate();

            var called = false;
            _hashGenerator.Setup(x => x.ToHash(It.Is<string>(str => str.Equals(expected.Url))))
                .Callback(() =>
                {
                    if (!called)
                    {
                        _urlDbContext.Add(expected);
                        _urlDbContext.SaveChanges();
                        called = true;
                    }
                })
                .Returns(_faker.Random.String2(HashLength));

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
            result.Result.ShouldBe(ShortenUrlResult.AlreadyExists);
        }

        [Fact]
        public async Task HandleShouldRecreateHashIfItUserDuringRequest()
        {
            // Arrange
            var expected = _shortUrlFaker.Generate();

            var called = false;
            var hashToReturn = expected.Hash;
            _hashGenerator.Setup(x => x.ToHash(It.Is<string>(str => str.Equals(expected.Url))))
                .Callback(() =>
                {
                    if (!called)
                    {
                        var model = new ShortUrl
                        {
                            Hash = expected.Hash,
                            Url = _faker.Internet.Url(),
                            CreatedAt = expected.CreatedAt
                        };

                        _additionallyTracked.Add(model);

                        _urlDbContext.Add(model);
                        _urlDbContext.SaveChanges();
                        called = true;
                    } 
                    else
                    {
                        hashToReturn = _faker.Random.String2(HashLength);
                    }
                })
                .Returns(() => hashToReturn);

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
            result.Url.ShouldBe($"{_baseAddress}/{hashToReturn}");
            result.Result.ShouldBe(ShortenUrlResult.Created);

            _hashGenerator.Verify(x => x.ToHash(It.Is<string>(s => s == expected.Url)),
                Times.Exactly(2));
        }

        public void Dispose()
        {
            _urlDbContext.RemoveRange(_urlDbContext.ChangeTracker
                .Entries()
                .Select(x => x.Entity)
                .Concat(_additionallyTracked));

            _urlDbContext.SaveChanges();
            _urlDbContext.Dispose();
        }
    }
}

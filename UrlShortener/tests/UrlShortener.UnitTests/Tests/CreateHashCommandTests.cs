using Microsoft.Extensions.Logging;
using Moq;
using UrlShortener.Domain.Commands;
using UrlShortener.Domain.Services.Interfaces;

namespace UrlShortener.UnitTests.Tests
{
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
    }
}
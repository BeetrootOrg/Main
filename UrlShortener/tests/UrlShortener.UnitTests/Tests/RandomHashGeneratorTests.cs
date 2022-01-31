using Shouldly;
using UrlShortener.Domain.Services;
using Xunit;

namespace UrlShortener.UnitTests.Tests
{
    public class RandomHashGeneratorTests
    {
        [Theory]
        [InlineData(8, 1e5)]
        [InlineData(12, 1e4)]
        [InlineData(16, 1e3)]
        public void ToHashShouldGenerateRandomHashEachTime(int length, int repeatTime)
        {
            // Arrange
            const string data = "str1";
            var generator = new RandomHashGenerator(length);
            
            // Act
            for (var i = 0; i < repeatTime; i++)
            {
                var hash1 = generator.ToHash(data);
                var hash2 = generator.ToHash(data);
                
                // Assert
                hash1.ShouldNotBe(hash2);
            }
        }
    }
}
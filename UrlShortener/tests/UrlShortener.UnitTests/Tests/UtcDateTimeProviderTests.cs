using System;
using Shouldly;
using UrlShortener.Domain.Services;
using Xunit;

namespace UrlShortener.UnitTests.Tests
{
    public class UtcDateTimeProviderTests
    {
        [Theory]
        [InlineData(100, 1000)]
        public void NowShouldAlwaysReturnCorrectTime(int epsMs, int repeatTimes)
        {
            // Arrange
            var dateTimeProvider = new UtcDateTimeProvider();
            
            // Act
            for (var i = 0; i < repeatTimes; i++)
            {
                var actual = dateTimeProvider.Now;
                var expected = DateTime.UtcNow;
                
                Math.Abs((actual - expected).TotalMilliseconds).ShouldBeLessThanOrEqualTo(epsMs);
            }
        }
    }
}
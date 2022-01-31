using UrlShortener.Domain;

namespace UrlShortener.Api
{
    public class ApiConfiguration : IDomainConfiguration
    {
        public int HashLength { get; init; } = 8;
    }
}
namespace UrlShortener.Domain
{
    public interface IDomainConfiguration
    {
        int HashLength { get; }
        string BaseAddress { get; }
    }
}
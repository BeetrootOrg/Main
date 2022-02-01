namespace UrlShortener.Domain
{
    public interface IDomainConfiguration
    {
        int HashLength { get; }
        string Domain { get; }
    }
}
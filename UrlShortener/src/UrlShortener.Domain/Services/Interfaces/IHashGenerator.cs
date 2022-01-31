namespace UrlShortener.Domain.Services.Interfaces
{
    internal interface IHashGenerator
    {
        string ToHash(string original);
    }
}
namespace UrlShortener.Api.Models
{
    public class ErrorResponse
    {
        public string Message { get; init; }
        public object Details { get; init; }
    }
}
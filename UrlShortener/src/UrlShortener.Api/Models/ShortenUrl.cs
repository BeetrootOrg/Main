using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Api.Models
{
    public class ShortenUrlRequest
    {
        [StringLength(255, ErrorMessage = "Url cannot be longer than 255 symbols", MinimumLength = 1)]
        public string Url { get; init; }
    }

    public class ShortenUrlResponse
    {
        public string ShortUrl { get; init; }
    }
}
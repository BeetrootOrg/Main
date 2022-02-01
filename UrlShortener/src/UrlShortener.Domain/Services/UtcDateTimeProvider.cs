using System;
using UrlShortener.Domain.Services.Interfaces;

namespace UrlShortener.Domain.Services
{
    internal class UtcDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
using System;

namespace UrlShortener.Domain.Services.Interfaces
{
    internal interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
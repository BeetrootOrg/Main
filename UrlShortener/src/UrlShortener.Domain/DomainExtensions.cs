using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Domain.Queries;

namespace UrlShortener.Domain
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(GetUrlQuery).Assembly);
            return serviceCollection;
        }
    }
}
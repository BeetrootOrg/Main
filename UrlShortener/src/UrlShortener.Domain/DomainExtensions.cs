using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UrlShortener.Domain.Commands;
using UrlShortener.Domain.Queries;
using UrlShortener.Domain.Services;
using UrlShortener.Domain.Services.Interfaces;

namespace UrlShortener.Domain
{
    public static class DomainExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection serviceCollection,
            Func<IServiceProvider, IOptionsMonitor<IDomainConfiguration>> domainConfigurationFunc)
        {
            serviceCollection.AddMediatR(typeof(GetLongUrlQuery).Assembly);
            serviceCollection.AddTransient(sp =>
            {
                var configuration = domainConfigurationFunc(sp);
                return new ShortenUrlCommandHandlerConfig
                {
                    BaseAddress = configuration.CurrentValue.BaseAddress
                };
            });
            
            serviceCollection.AddSingleton<IHashGenerator>(
                sp =>
                {
                    var configuration = domainConfigurationFunc(sp);
                    return new RandomHashGenerator(configuration.CurrentValue.HashLength);
                });

            serviceCollection.AddSingleton<IDateTimeProvider, UtcDateTimeProvider>();
            
            return serviceCollection;
        }
    }
}
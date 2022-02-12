using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ResourceSharing.Domain.Commands;
using ResourceSharing.Domain.Repositories;
using ResourceSharing.Domain.Repositories.Interfaces;

namespace ResourceSharing.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(CreateSchemaCommandHandler).Assembly);
            serviceCollection.AddTransient<ISchemaRepository, SchemaRepository>();
            return serviceCollection;
        }
    }
}

using ResourceSharing.Domain.Models.Db;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceSharing.Domain.Repositories.Interfaces
{
    public interface ISchemaRepository
    {
        Task AddSchema(SchemaDto schemaDto, CancellationToken cancellationToken = default);
        Task<SchemaDto> GetSchemaByName(string name, CancellationToken cancellationToken = default);
    }
}

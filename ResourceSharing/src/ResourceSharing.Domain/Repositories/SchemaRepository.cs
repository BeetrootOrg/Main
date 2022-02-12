using Dapper;
using ResourceSharing.Domain.Models.Db;
using ResourceSharing.Domain.Repositories.Interfaces;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceSharing.Domain.Repositories
{
    internal class SchemaRepository : ISchemaRepository
    {
        private const string AddSchemaQuery = @"INSERT INTO dbo.Schemas(SchemaName, SchemaDefinition) 
                                                    VALUES (@SchemaName, @SchemaDefinition)";

        private const string GetSchemaByNameQuery = @"SELECT Id, SchemaName, SchemaDefinition
                                                        FROM dbo.Schemas
                                                        WHERE SchemaName = @Name";

        private readonly IDbConnection _dbConnection;

        public SchemaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task AddSchema(SchemaDto schemaDto, CancellationToken cancellationToken = default)
        {
            var command = new CommandDefinition(AddSchemaQuery,
                schemaDto,
                commandType: CommandType.Text,
                cancellationToken: cancellationToken);

            return _dbConnection.ExecuteAsync(command);
        }

        public Task<SchemaDto> GetSchemaByName(string name, CancellationToken cancellationToken = default)
        {
            var command = new CommandDefinition(GetSchemaByNameQuery,
                new { Name = name },
                commandType: CommandType.Text,
                cancellationToken: cancellationToken);

            return _dbConnection.QuerySingleOrDefaultAsync<SchemaDto>(command);
        }
    }
}

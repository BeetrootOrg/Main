using Dapper;
using ResourceSharing.Domain.Models;
using ResourceSharing.Domain.Models.Db;
using ResourceSharing.Domain.Repositories.Interfaces;
using System;
using System.Data;
using System.Text;
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

        public Task CreateTableUsingSchema(SchemaDto schemaDto, CancellationToken cancellationToken = default)
        {
            var queryBuilder = new StringBuilder("CREATE TABLE");
            queryBuilder.Append($" [dbo].[{schemaDto.SchemaName}]");
            queryBuilder.Append("(");

            foreach (var field in schemaDto.Fields)
            {
                queryBuilder.Append($"{field.Name}");
                queryBuilder.Append($" {GetType(field.Type)}");
                queryBuilder.Append($" {GetConstraints(field)}");
                queryBuilder.Append($",");
            }

            queryBuilder.Remove(queryBuilder.Length - 1, 1);
            queryBuilder.Append(")");

            var command = new CommandDefinition(queryBuilder.ToString(),
                schemaDto,
                commandType: CommandType.Text,
                cancellationToken: cancellationToken);

            return _dbConnection.ExecuteAsync(command);

            static string GetType(DataType dataType) => dataType switch
            {
                DataType.Int => "INT",
                DataType.String => "TEXT",
                DataType.Bool => "BIT",
                _ => throw new ArgumentOutOfRangeException(nameof(dataType)),
            };

            static string GetConstraints(DataField field)
            {
                var constaints = GetDefaultConstraint(field);
                if (field.Required)
                {
                    constaints += " NOT NULL";
                }

                return constaints;
            }

            static string GetDefaultConstraint(DataField field)
            {
                const string nullValue = "NULL";
                const string one = "1";
                const string zero = "0";

                return field.Type switch
                {
                    DataType.Int => $"DEFAULT {field.Default ?? nullValue}",
                    DataType.String => $"DEFAULT {(field.Default == null ? $"'{field.Default}'" : nullValue)}",
                    DataType.Bool => $"DEFAULT {(field.Default == null ? nullValue : (bool.TryParse(field.Default, out var value) && value ? one : zero))}",
                    _ => throw new ArgumentOutOfRangeException(nameof(field.Type))
                };
            }
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

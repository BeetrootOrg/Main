using MediatR;
using Microsoft.Extensions.Logging;
using ResourceSharing.Domain.Models;
using ResourceSharing.Domain.Models.Db;
using ResourceSharing.Domain.Repositories.Interfaces;
using ResourceSharing.Domain.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceSharing.Domain.Commands
{
    public record CreateSchemaCommand : IRequest<CreateSchemaCommandResult>
    {
        public string SchemaName { get; init; }
        public IEnumerable<DataField> Fields { get; init; }
    }

    public enum CreateSchemaResult
    {
        Created,
        NotValid,
        AlreadyExists
    }

    public record CreateSchemaCommandResult
    {
        public CreateSchemaResult Result { get; init; }
    }

    internal class CreateSchemaCommandHandler : IRequestHandler<CreateSchemaCommand, CreateSchemaCommandResult>
    {
        private readonly ISchemaRepository _schemaRepository;
        private readonly ILogger<CreateSchemaCommandHandler> _logger;

        public CreateSchemaCommandHandler(ISchemaRepository schemaRepository, 
            ILogger<CreateSchemaCommandHandler> logger)
        {
            _schemaRepository = schemaRepository;
            _logger = logger;
        }

        public async Task<CreateSchemaCommandResult> Handle(CreateSchemaCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Executing command {CommandName} with next parameters: {@Request}",
                nameof(CreateSchemaCommand),
                request);

            // check if schema exists
            var schemaDb = await _schemaRepository.GetSchemaByName(request.SchemaName, cancellationToken);

            if (schemaDb != null)
            {
                _logger.LogDebug("Schema {Name} already exists", request.SchemaName);

                // schema exists = finish
                return new CreateSchemaCommandResult
                {
                    Result = CreateSchemaResult.AlreadyExists
                };
            }

            if (!DataFiledsHelper.IsSchemaValid(request.Fields))
            {
                _logger.LogDebug("Schema {Schema} is not valid", request.Fields);

                return new CreateSchemaCommandResult
                {
                    Result = CreateSchemaResult.NotValid
                };
            }

            var newSchemaDb = new SchemaDto
            {
                SchemaName = request.SchemaName,
                Fields = request.Fields
            };

            await _schemaRepository.AddSchema(newSchemaDb, cancellationToken);
            await _schemaRepository.CreateTableUsingSchema(newSchemaDb, cancellationToken);

            var result = new CreateSchemaCommandResult
            {
                Result = CreateSchemaResult.Created
            };

            _logger.LogInformation("Executed command {CommandName} with next parameters: {@Request}. Result: {@Result}",
                nameof(CreateSchemaCommand),
                request,
                result);

            return result;
        }
    }
}

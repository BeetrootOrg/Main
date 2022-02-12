using MediatR;
using Newtonsoft.Json;
using ResourceSharing.Domain.Models;
using ResourceSharing.Domain.Models.Db;
using ResourceSharing.Domain.Repositories.Interfaces;
using ResourceSharing.Domain.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceSharing.Domain.Commands
{
    public class CreateSchemaCommand : IRequest<CreateSchemaCommandResult>
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

    public class CreateSchemaCommandResult
    {
        public CreateSchemaResult Result { get; init; }
    }

    public class CreateSchemaCommandHandler : IRequestHandler<CreateSchemaCommand, CreateSchemaCommandResult>
    {
        private readonly ISchemaRepository _schemaRepository;

        public CreateSchemaCommandHandler(ISchemaRepository schemaRepository)
        {
            _schemaRepository = schemaRepository;
        }

        public async Task<CreateSchemaCommandResult> Handle(CreateSchemaCommand request, CancellationToken cancellationToken)
        {
            // check if schema exists
            var schemaDb = await _schemaRepository.GetSchemaByName(request.SchemaName, cancellationToken);

            if (schemaDb != null)
            {
                // schema exists = finish
                return new CreateSchemaCommandResult
                {
                    Result = CreateSchemaResult.AlreadyExists
                };
            }

            if (!DataFiledsHelper.IsSchemaValid(request.Fields))
            {
                return new CreateSchemaCommandResult
                {
                    Result = CreateSchemaResult.NotValid
                };
            }

            var newSchemaDb = new SchemaDto
            {
                SchemaName = request.SchemaName,
                SchemaDefinition = JsonConvert.SerializeObject(request.Fields)
            };

            await _schemaRepository.AddSchema(newSchemaDb, cancellationToken);

            return new CreateSchemaCommandResult
            {
                Result = CreateSchemaResult.Created
            };
        }
    }
}

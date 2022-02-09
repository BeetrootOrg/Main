using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResourceSharing.Api.Models;
using ResourceSharing.Domain.Commands;
using ResourceSharing.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceSharing.Api.Controllers
{
    [Route("api/schema")]
    public class SchemaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{schemaName}")]
        public async Task<IActionResult> CreateSchema([FromRoute] string schemaName, 
            [FromBody] CreateSchemaRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateSchemaCommand
            {
                SchemaName = schemaName,
                Fields = request.Fields.Select(field => new DataField
                {
                    Default = field.Default,
                    Name = field.Name,
                    Required = field.Required,
                    Type = (Domain.Models.DataType)field.Type
                })
            };

            var result = await _mediator.Send(command, cancellationToken);

            // ToDo: update url
            return result.Result switch
            {
                CreateSchemaResult.AlreadyExists => Conflict(),
                CreateSchemaResult.NotValid => BadRequest(),
                CreateSchemaResult.Created => Created("http://ToDo.com", null),
                _ => StatusCode(500)
            };
        }
    }
}

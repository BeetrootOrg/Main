using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResourceSharing.Api.Models;
using ResourceSharing.Domain.Commands;
using ResourceSharing.Domain.Models;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> CreateSchema([FromRoute] 
            [StringLength(40, MinimumLength = 1, ErrorMessage = "Schema name length should be between 1 and 40")] string schemaName, 
            [FromBody] CreateSchemaRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

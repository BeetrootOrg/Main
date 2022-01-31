using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Api.Models;
using UrlShortener.Domain.Queries;

namespace UrlShortener.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UrlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Redirect to resource by it hash
        /// </summary>
        /// <param name="hash">URL's hash</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        [HttpGet("{hash}")]
        [ProducesResponseType(302)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<ActionResult> GetRouteByHash(string hash, CancellationToken cancellationToken = default)
        {
            var query = new GetUrlQuery
            {
                Hash = hash
            };

            var result = await _mediator.Send(query, cancellationToken);

            if (result.Result == SearchUrlResult.Success)
            {
                return Redirect(result.Url);
            }

            return result.Result switch
            {
                SearchUrlResult.Success => Redirect(result.Url),
                SearchUrlResult.NotFound => NotFound(new ErrorResponse
                {
                    Details = new
                    {
                        Hash = hash
                    },
                    Message = result.Message
                }),
                _ => StatusCode(500, new ErrorResponse
                {
                    Details = new
                    {
                        Hash = hash
                    },
                    Message = $"Unknown result {result.Result}"
                })
            };
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace UrlShortener.Domain.Common
{
    internal abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;

        protected BaseHandler(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await HandleInternal(request, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception happened during {@Request} handling", request);
                throw;
            }
        }

        protected abstract Task<TResponse> HandleInternal(TRequest request, CancellationToken cancellationToken);
    }
}
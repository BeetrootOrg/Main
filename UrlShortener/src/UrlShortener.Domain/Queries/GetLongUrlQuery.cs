using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UrlShortener.Database.Context;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Queries
{
    public class GetLongUrlQuery : IRequest<GetLongUrlQueryResponse>
    {
        public string Hash { get; init; }
    }

    public enum SearchUrlResult
    {
        Success,
        NotFound
    }

    public class GetLongUrlQueryResponse
    {
        public string Url { get; init; }
        public SearchUrlResult Result { get; init; }
        public string Message { get; init; }
    }
    
    internal class GetLongUrlQueryHandler : BaseHandler<GetLongUrlQuery, GetLongUrlQueryResponse>
    {
        private readonly ILogger<GetLongUrlQueryHandler> _logger;
        private readonly UrlDbContext _dbContext;

        public GetLongUrlQueryHandler(ILogger<GetLongUrlQueryHandler> logger, UrlDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        protected override async Task<GetLongUrlQueryResponse> HandleInternal(GetLongUrlQuery request, CancellationToken cancellationToken)
        {
            var lowerHash = request.Hash.ToLower();
            var url = await _dbContext.Urls.SingleOrDefaultAsync(url => url.Hash.ToLower() == lowerHash, 
                cancellationToken);

            if (url == null)
            {
                _logger.LogDebug("Url not found in DB. Request: {@Request}", request);
                
                return new GetLongUrlQueryResponse
                {
                    Message = $"Url with hash '{request.Hash}' not found",
                    Result = SearchUrlResult.NotFound
                };
            }
            
            _logger.LogDebug("Url found in DB. Request: {@Request}. Result: {@Url}", 
                request, 
                url.Url);
            
            return new GetLongUrlQueryResponse
            {
                Result = SearchUrlResult.Success,
                Url = url.Url
            };
        }
    }
}
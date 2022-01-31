using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UrlShortener.Database.Context;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Queries
{
    public class GetUrlQuery : IRequest<GetUrlQueryResponse>
    {
        public string Hash { get; init; }
    }

    public enum SearchUrlResult
    {
        Success,
        NotFound
    }

    public class GetUrlQueryResponse
    {
        public string Url { get; init; }
        public SearchUrlResult Result { get; init; }
        public string Message { get; init; }
    }
    
    internal class GetLongUrlQueryHandler : BaseHandler<GetUrlQuery, GetUrlQueryResponse>
    {
        private readonly ILogger<GetLongUrlQueryHandler> _logger;
        private readonly UrlDbContext _dbContext;

        public GetLongUrlQueryHandler(ILogger<GetLongUrlQueryHandler> logger, UrlDbContext dbContext)
            : base(logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        protected override async Task<GetUrlQueryResponse> HandleInternal(GetUrlQuery request, CancellationToken cancellationToken)
        {
            var lowerHash = request.Hash.ToLower();
            var url = await _dbContext.Urls.SingleOrDefaultAsync(url => url.Hash.ToLower() == lowerHash, 
                cancellationToken);

            if (url == null)
            {
                _logger.LogDebug("Url not found in DB. Request: {@Request}", request);
                
                return new GetUrlQueryResponse
                {
                    Message = $"Url with hash '{request.Hash}' not found",
                    Result = SearchUrlResult.NotFound
                };
            }
            
            _logger.LogDebug("Url found in DB. Request: {@Request}. Result: {@Url}", 
                request, 
                url.Url);
            
            return new GetUrlQueryResponse
            {
                Result = SearchUrlResult.Success,
                Url = url.Url
            };
        }
    }
}
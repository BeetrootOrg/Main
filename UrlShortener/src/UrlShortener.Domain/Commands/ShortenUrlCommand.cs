using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using UrlShortener.Database.Context;
using UrlShortener.Database.Models;
using UrlShortener.Domain.Common;
using UrlShortener.Domain.Services.Interfaces;

namespace UrlShortener.Domain.Commands
{
    public class ShortenUrlCommand : IRequest<ShortenUrlCommandResponse>
    {
        public string Url { get; init; }
    }

    public enum ShortenUrlResult
    {
        Created,
        AlreadyExists
    }

    public class ShortenUrlCommandResponse
    {
        public string Url { get; init; }
        public ShortenUrlResult Result { get; set; }
    }

    internal class ShortenUrlCommandHandlerConfig
    {
        public string BaseAddress { get; init; }
    }
    
    internal class ShortenUrlCommandHandler : BaseHandler<ShortenUrlCommand, ShortenUrlCommandResponse>
    {
        private const int RetryTimes = 5;

        private readonly ILogger<ShortenUrlCommandHandler> _logger;
        private readonly UrlDbContext _dbContext;
        private readonly IHashGenerator _hashGenerator;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly string _baseAddress;
        
        public ShortenUrlCommandHandler(ILogger<ShortenUrlCommandHandler> logger, 
            UrlDbContext dbContext, 
            IHashGenerator hashGenerator, 
            IDateTimeProvider dateTimeProvider,
            ShortenUrlCommandHandlerConfig config) : base(logger)
        {
            _logger = logger;
            _dbContext = dbContext;
            _hashGenerator = hashGenerator;
            _dateTimeProvider = dateTimeProvider;
            _baseAddress = config.BaseAddress.TrimEnd('/');
        }

        protected override Task<ShortenUrlCommandResponse> HandleInternal(ShortenUrlCommand request, CancellationToken cancellationToken) =>
            Policy
                .Handle<DbUpdateException>()
                .RetryAsync(RetryTimes, (exception, times) =>
                {
                    _logger.LogWarning(exception, "Retry on specific exception. Times: {@Times}", times);
                })
                .ExecuteAsync(() => ExecuteInternal(request, cancellationToken));

        private async Task<ShortenUrlCommandResponse> ExecuteInternal(ShortenUrlCommand request,
            CancellationToken cancellationToken)
        {
            var lowerUrl = request.Url.ToLower();
            var realUrlHash = await _dbContext.Urls.SingleOrDefaultAsync(url => url.Url.ToLower() == lowerUrl, 
                cancellationToken);

            if (realUrlHash != null)
            {
                _logger.LogDebug("Hash for {@Url} found in DB. Hash: {@Hash}",
                    request.Url,
                    realUrlHash.Hash);

                return new ShortenUrlCommandResponse
                {
                    Url = ToUrl(realUrlHash.Hash),
                    Result = ShortenUrlResult.AlreadyExists
                };
            }
            
            var urlHash = _hashGenerator.ToHash(request.Url);
            var shortUrl = new ShortUrl
            {
                Hash = urlHash,
                Url = request.Url,
                CreatedAt = _dateTimeProvider.Now
            };
            
            _logger.LogDebug("Trying to save URL hash. Hash: {@Hash}", shortUrl);

            await _dbContext.Urls.AddAsync(shortUrl, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ShortenUrlCommandResponse
            {
                Url = ToUrl(shortUrl.Hash),
                Result = ShortenUrlResult.Created
            };

            string ToUrl(string hash) => $"{_baseAddress}/{hash}";
        }
    }
}
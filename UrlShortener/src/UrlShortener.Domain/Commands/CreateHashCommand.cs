using System;
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
    public class CreateHashCommand : IRequest<CreateHashCommandResponse>
    {
        public string Url { get; init; }
    }

    public class CreateHashCommandResponse
    {
        public string Hash { get; init; }
    }
    
    internal class CreateHashCommandHandler : BaseHandler<CreateHashCommand, CreateHashCommandResponse>
    {
        private const int RetryTimes = 5;

        private readonly ILogger<CreateHashCommandHandler> _logger;
        private readonly UrlDbContext _dbContext;
        private readonly IHashGenerator _hashGenerator;
        private readonly IDateTimeProvider _dateTimeProvider;
        
        public CreateHashCommandHandler(ILogger<CreateHashCommandHandler> logger, 
            UrlDbContext dbContext, 
            IHashGenerator hashGenerator, 
            IDateTimeProvider dateTimeProvider) : base(logger)
        {
            _logger = logger;
            _dbContext = dbContext;
            _hashGenerator = hashGenerator;
            _dateTimeProvider = dateTimeProvider;
        }

        protected override Task<CreateHashCommandResponse> HandleInternal(CreateHashCommand request, CancellationToken cancellationToken) =>
            Policy
                .Handle<Exception>()
                .RetryAsync(RetryTimes, (exception, times) =>
                {
                    _logger.LogWarning(exception, "Retry on specific exception. Times: {@Times}", times);
                })
                .ExecuteAsync(() => ExecuteInternal(request, cancellationToken));

        private async Task<CreateHashCommandResponse> ExecuteInternal(CreateHashCommand request,
            CancellationToken cancellationToken)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            var lowerUrl = request.Url.ToLower();
            var realUrlHash = await _dbContext.Urls.SingleOrDefaultAsync(url => url.Url.ToLower() == lowerUrl, 
                cancellationToken);

            if (realUrlHash != null)
            {
                _logger.LogDebug("Hash for {@Url} found in DB. Hash: {@Hash}",
                    request.Url,
                    realUrlHash.Hash);

                return new CreateHashCommandResponse
                {
                    Hash = realUrlHash.Hash
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
            await transaction.CommitAsync(cancellationToken);

            return new CreateHashCommandResponse
            {
                Hash = shortUrl.Hash
            };
        }
    }
}
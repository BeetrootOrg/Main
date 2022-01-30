using Microsoft.EntityFrameworkCore;
using UrlShortener.Database.Models;

namespace UrlShortener.Database.Context
{
    public class UrlDbContext : DbContext
    {
        public DbSet<ShortUrl> Urls { get; init; }

        public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options)
        {
        }
    }
}

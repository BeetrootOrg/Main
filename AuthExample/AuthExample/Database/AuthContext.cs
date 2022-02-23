using AuthExample.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace AuthExample.Database
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; init; }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }
    }
}

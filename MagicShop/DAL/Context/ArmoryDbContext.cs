using DAL.Entites;
using DAL.Entites.Base;
using DLL.Entites;
using DLL.Entites.Base;
using Microsoft.EntityFrameworkCore;

namespace DLL.Context
{
    public class ArmoryDbContext : DbContext
    {
        public ArmoryDbContext(DbContextOptions<ArmoryDbContext> options) :base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BaseFile> Files { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<MagicWeapon> MagicWeapon { get; set; }
        public DbSet<RangeWeapon> RangeWeapon { get; set; }
        public DbSet<MeleeWeapon> MeleeWeapon { get; set; }

       
    }
}

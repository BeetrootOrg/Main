using DLL.Entites;
using DLL.Entites.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Context
{
    public class ArmoryDbContext : DbContext
    {
        public ArmoryDbContext(DbContextOptions<ArmoryDbContext> options) :base (options)
        {
        }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<MagicWeapon> MagicWeapon { get; set; }
        public DbSet<RangeWeapon> RangeWeapon { get; set; }
        public DbSet<MeleeWeapon> MeleeWeapon { get; set; }

    }
}

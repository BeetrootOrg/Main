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
        public DbSet<Role> Roles { get; set; }
        public DbSet<BaseFile> Files { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<MagicWeapon> MagicWeapon { get; set; }
        public DbSet<RangeWeapon> RangeWeapon { get; set; }
        public DbSet<MeleeWeapon> MeleeWeapon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ua";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new() { Id = 1, Name = adminRoleName };
            Role userRole = new() { Id = 2, Name = userRoleName };
            User adminUser = new() { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }

    }
}

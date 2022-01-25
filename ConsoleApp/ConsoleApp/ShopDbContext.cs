using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp
{
    internal class ShopDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public ShopDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=OrdersDB;Trusted_Connection=True;");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}

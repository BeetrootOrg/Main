using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Database
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CountOfEachBook> BookCount { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HistoryBook> HistoryBooks { get; set; }

        public OrderDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HR3E54O\SQLEXPRESS;Database=LiberaryDb;Trusted_Connection=True");
        }
    }
}

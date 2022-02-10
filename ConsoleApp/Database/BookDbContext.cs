using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Database
{
    public class BookDbContext :DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HistoryOfReading> HistoryOfReadings { get; set; }

        public BookDbContext() :base() 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}


using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{

    public record Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public record Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Edition { get; set; }
    }
    public record BookCount
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public int? BookId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
        public int? Quantity { get; set; }

    }
    public class LibraryDBContext : DbContext
    {

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
           : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCount> BookCounts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=NewBookLibraryDB;Trusted_Connection=True;");
            }
        }
     
    }
    public class Program
    {
        private static void Main()
        {

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                           .UseSqlServer("Server=localhost;Database=NewBookLibraryDB;Trusted_Connection=True;")
                           .Options;


            using var db = new LibraryDBContext(options);

            db.Database.EnsureCreated();


        }

    }
}

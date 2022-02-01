using ConsoleApp.Database;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        private static async Task Main()
        {
            /*
            1. dotnet new tool-manifest
            2. dotnet tool install dotnet-ef
            3. dotnet ef dbcontext scaffold "Server=localhost;Database=BookLibraryDB;Trusted_Connection=True;" "Microsoft.EntityFrameworkCore.SqlServer" --context BookLibraryDBContext --context-dir Database --output-dir Models
            4. dotnet ef migrations add Initial
            5. dotnet ef database update
            */
            Console.WriteLine("\r\n a.tkachenko/homework/28-EF \r\n");

            await using var dbContext = new BookLibraryDBContext();

            await dbContext.BookCounts.AddAsync(new BookCount
            {
                Book = new Book
                {
                    Title = "Title " + Guid.NewGuid().ToString(),
                    Edition = DateTime.Now,
                },
                Author = new Author
                {
                    Name = "Author " + Guid.NewGuid().ToString(),
                }
            });

            await dbContext.SaveChangesAsync();
            await foreach (var bc in dbContext.BookCounts)
            {
                Console.WriteLine(bc);
            }

            var result = dbContext.BookCounts.Join(dbContext.Books,
                bookCount => bookCount.BookId,
                book => book.Id,
                (bookCount, book) => new
                {
                    bookCount.Quantity,
                    book.Title
                });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            // update
            var maxBookCounts = await dbContext.BookCounts.MaxAsync(x => x.Quantity);
            var maxBooks = await dbContext.BookCounts.FirstAsync(x => x.Quantity == maxBookCounts);
            maxBooks.Quantity += 1;
            dbContext.BookCounts.Update(maxBooks);

            // delete
            var minBookCounts = await dbContext.BookCounts.MinAsync(x => x.Quantity);
            var minBooks = await dbContext.BookCounts.FirstAsync(x => x.Quantity == minBookCounts);

            dbContext.BookCounts.Remove(minBooks);
            await dbContext.SaveChangesAsync();
        }
    }
}
using Library.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Program
    {
        private static async Task Main()
        {
            await using var dbContext = new LibraryDBContext();
            
            var history = await dbContext.Histories
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .ThenInclude(x => x.Author)
                .Where(x => x.Id == 3)
                .ToArrayAsync();

            foreach (var item in history)
            {
                Console.WriteLine($"Данные читателя :{item.Customer.FirstName} {item.Customer.LastName}" +
                                  $" | Дата выдачи: { item.DateWhenTaken}| Название Книги: {item.Book.NameBook} Имя Автора:" +
                                  $" {item.Book.Author.FirstName} {item.Book.Author.LastName} ");
            }
        }
    }
}
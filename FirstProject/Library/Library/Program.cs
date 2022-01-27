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
            var list = dbContext.Histories.Include(c=>c.Customer).ToList()
                .Where(c => c.Id ==3);
            var listBook =dbContext.Histories.Include(b=>b.Book).ToList().Where(b=>b.Id==3);
            var book = dbContext.Books.Include(a => a.Author).ToList().Where(c=>c.AuthorId==1);
            foreach(var item in list)
            {
                foreach (var itemBook in listBook)
                {
                    foreach (var items in book) {
                        Console.WriteLine($"Данные читателя :{item.Customer.FirstName} {item.Customer.LastName}" +
                            $" | Дата выдачи: { item.DateWhenTaken}| Название Книги: {item.Book.NameBook} Имя Автора:" +
                            $" {items.Author.FirstName} {items.Author.LastName} ");
                    }
                }
            }
        }
  
      

    }
}
using ConsoleApp.Database;
using ConsoleApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        private static async Task Main()
        {
            var random = new Random((int)DateTime.Now.Ticks);

            await using var dbContext = new OrderDbContext();

            await dbContext.Orders.AddAsync(new Order
            {
                Customer = new Customer
                {
                    FirstName = Guid.NewGuid().ToString(),
                    LastName = Guid.NewGuid().ToString()
                },
                PurchaseAmount = new decimal(random.NextDouble() * 100),
                PurchasedAt = DateTime.Now,
                Salesman = new Salesman
                {
                    FirstName = Guid.NewGuid().ToString(),
                    LastName = Guid.NewGuid().ToString()
                }
            });

            await dbContext.SaveChangesAsync();
            await foreach (var order in dbContext.Orders)
            {
                Console.WriteLine(order);
            }

            var result = dbContext.Orders.Join(dbContext.Customers,
                order => order.CustomerId,
                customer => customer.Id,
                (order, customer) => new
                {
                    order.PurchaseAmount,
                    customer.FirstName,
                    customer.LastName
                });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
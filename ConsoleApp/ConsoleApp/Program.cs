using ConsoleApp.Database;
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
            await using var dbContext = new OrderDBContext();
            var orders = await dbContext.Orders
                .Where(order => order.Customer.LastName == "Guy")
                .ToArrayAsync();

            foreach (var order in orders)
            {
                Console.WriteLine($"Purchase amount is {order.PurchaseAmount}");
            }
        }
    }
}
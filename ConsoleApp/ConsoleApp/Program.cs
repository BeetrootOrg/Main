using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await using var dbContext = new ShopDbContext();
        var orders = await dbContext.Orders
            .Where(x => x.CustomerId == 1)
            .ToArrayAsync();

        await dbContext.Orders.AddAsync(new Order
        {
            CustomerId = 1,
            OrderDateTime = DateTime.Now,
            PurchaseAmount = 42,
            SalesmanId = 1,
        });

        await dbContext.SaveChangesAsync();
    }
}
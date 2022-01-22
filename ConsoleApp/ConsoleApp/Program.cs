using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ConsoleApp;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var contextOptions = new DbContextOptionsBuilder<ShopDbContext>();

        await using var dbContext = new ShopDbContext(contextOptions.Options);
        var orders = await dbContext.Orders.FirstAsync();
    }
}
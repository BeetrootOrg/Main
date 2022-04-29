
using System;
using System.IO;
using WebApplication.Controllers;
using WebApplication.Models;
using WebApplication.Services;
using Xunit;
using Moq;
using WebApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Data.Sqlite;

namespace WebApplicationTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            //Arrange

            //var model = new UnitTest1();

            Order ord = new Order();
            ord.Id = 1;
            ord.Flash = "silicon power";
            ord.Customer = "Вася Пупкин";
            ord.Ord = "345";
            ord.Steel = "нерж";
            ord.Surface = "Rz80";
            ord.Thickness = 2;
            ord.Qty = 1;
            ord.Bending = "да";
            ord.Dimension1 = 1200;
            ord.Dimension2 = 2400;
            ord.Note = "";
            ord.Manager = "Лёня Голубков";
            ord.Operator = "Семён Горбунков";
            ord.Modified = DateTime.Now;
            try
            {
                File.Delete("c:\\Temp 2\\blank.pdf");
            }
            catch (IOException ioExp)
            {
            };

            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase((Guid.NewGuid().ToString()))
                .Options;

            OrderDbContext fakeContext = new OrderDbContext(options);

            var set = new Mock<DbSet<Order>>();
            set.Object.AddRange(ord);

            fakeContext.Orders.Add(ord);
            fakeContext.SaveChanges();


            OrdersController controller = new OrdersController(fakeContext, new PdfService(fakeContext));

            //Act
            var res = new PdfService(fakeContext);
            var result = res.CreatePdf(1);


            //Assert
            Assert.True(File.Exists("c:\\Temp 2\\blank.pdf"));

        }
    }
}
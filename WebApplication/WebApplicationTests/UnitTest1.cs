
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
            ord.Customer = "���� ������";
            ord.Ord = "345";
            ord.Steel = "����";
            ord.Surface = "Rz80";
            ord.Thickness = 2;
            ord.Qty = 1;
            ord.Bending = "��";
            ord.Dimension1 = 1200;
            ord.Dimension2 = 2400;
            ord.Note = "";
            ord.Manager = "˸�� ��������";
            ord.Operator = "���� ���������";
            ord.Modified = DateTime.Now;
            try
            {
                File.Delete("c:\\Temp 2\\blank.pdf");
            }
            catch (IOException ioExp)
            {
            };

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer("Server=AMIGA\\SQLEXPRESS;Database=OrderDB;Trusted_Connection=True;");
               
            OrderDbContext fakeContext = new OrderDbContext(optionsBuilder.Options);

            fakeContext.Orders.Add(ord);
            //fakeContext.SaveChanges();


            //var mock = new Mock<Order>();
            //mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>() { new Computer() });
            //mock.Setup(a => a.OrderDbContext     GetComputerList()).Returns(new List<Computer>() { new Computer() });
            OrdersController controller = new OrdersController(fakeContext, new PdfService(fakeContext));

            //Act
            var res = new PdfService(fakeContext);
            var result = res.CreatePdf(1);


            //Assert
            Assert.True(File.Exists("c:\\Temp 2\\blank.pdf"));

        }
    }
}
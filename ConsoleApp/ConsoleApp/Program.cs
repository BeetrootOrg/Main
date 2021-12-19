using System;

namespace ConsoleApp
{
    public class Program
    {
        class InternetShop
        {
            Product[] Products;
            private Personal[] Personal;
            private RegisterBuyers[] Buyers;
            private Sales[] Sales;
        }

        class Product
        {
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public int Price { get; set; }
            public string ProductQuantity { get; set; }
        }

        class Personal
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
            public string FullName => $"{FirstName} {LastName}";
            public string PhoneNumber { get; set; }

        }

        class RegisterBuyers
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
            public string FullName => $"{FirstName} {LastName}";
            public string PhoneNumber { get; set; }
            Product[] Purchases { get; init; }
        }

        class Sales
        {
            Product[] SoldItem { get; init; }
            Personal Seller { get; init; }
            RegisterBuyers Buyer { get; init; }
            DateOnly SaleDate { get; init; }
        }

        static void Main()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
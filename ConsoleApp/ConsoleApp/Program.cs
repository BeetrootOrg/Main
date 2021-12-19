using System;

namespace ConsoleApp
{
    class InternetShop
    {
        Product[] Products;
        Personal[] Personal;
        RegisterBuyers[] Buyers;
        Sales[] Sales;
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
        public string FirstName { get; init;}
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
        Product[] Purchases { get; set; }
    }

    class Sales
    {
        Product[] SoldItem { get; set;}
        Personal Seller { get; set; }
        RegisterBuyers Buyer { get; set; }

    public class Program
    {
        static void Main()
        {

        }           
    }
}
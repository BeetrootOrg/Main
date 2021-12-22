using System;

namespace ConsoleApp
{
    public class Program
    {
        interface IShopMethods
        {
            void AddNewProduct(string productName, string productDescription, int price, int quantity);
            int ChangeQuantity(Product someProduct, int newQuantity);
            void AddNewSale(Product[] soldItem, Personal seller, RegisterBuyer buyer);
            void AddNewBuyer(string firstName, string lastName, string phoneNumber);
        }
        class InternetShop : IShopMethods
        {
            Product[] Products;
            private Personal[] Personal;
            private RegisterBuyer[] Buyers;
            private Sale[] Sales;

            public InternetShop() { }

            public int ChangeQuantity(Product someProduct, int newQuantity) => someProduct.Quantity = newQuantity;

            public void AddNewBuyer(string firstName, string lastName, string phoneNumber)
            {
                Array.Resize(ref Buyers, Buyers.Length + 1);
                Buyers[Buyers.Length - 1] = new RegisterBuyer(firstName, lastName, phoneNumber); 
            }

            public void AddNewProduct(string productName, string productDescription, int price, int quantity)
            {
                Array.Resize(ref Products, Products.Length + 1);
                Products[Products.Length - 1] = new Product(productName, productDescription, price, quantity);
            }

            public void AddNewSale(Product[] soldItem, Personal seller, RegisterBuyer buyer)
            {
                Array.Resize(ref Sales, Sales.Length + 1);
                Sales[Sales.Length - 1] = new Sale(soldItem, seller, buyer);
            }
        }

        class Product
        {
            public Product(string productName, string productDescription, int price, int quantity)
            {
                ProductName = productName;
                ProductDescription = productDescription;
                Price = price;
                Quantity = quantity;
            }

            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
        }

        class Personal
        {
            public Personal(string firstName, string lastName, string phoneNumber)
            {
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
            }

            public string FirstName { get; init; }
            public string LastName { get; init; }
            public string FullName => $"{FirstName} {LastName}";
            public string PhoneNumber { get; set; }

        }

        class RegisterBuyer
        {
            public RegisterBuyer(string firstName, string lastName, string phoneNumber)
            {
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
            }

            public string FirstName { get; init; }
            public string LastName { get; init; }
            public string FullName => $"{FirstName} {LastName}";
            public string PhoneNumber { get; set; }
        }

        class Sale
        {
            public Sale(Product[] soldItem, Personal seller, RegisterBuyer buyer)
            {
                SoldItem = soldItem;
                Seller = seller;
                Buyer = buyer;
                SaleDate = DateTime.Now;
            }

            Product[] SoldItem { get; init; }
            Personal Seller { get; init; }
            RegisterBuyer Buyer { get; init; }
            DateTime SaleDate { get; init; }
        }

        static void Main()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
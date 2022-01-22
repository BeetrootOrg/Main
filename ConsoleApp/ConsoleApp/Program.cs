using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    interface IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int AccountID { get; set; }
    }
    interface IProductOperations
    {
        void AddProductToBasket(Basket basket, Product product);
        void DeleteProductFromBasket(Basket basket, Product product);
        void AddReceipt(Receipt receipt);
    }
    public class InternetShop : IProductOperations
    {

        public void AddProductToBasket(Basket basket, Product product)
        {
            basket.quantity.Add(product);
        }
        public void DeleteProductFromBasket(Basket basket, Product product)
        {
            basket.quantity.Remove(product);

        }
        public void AddReceipt(Receipt receipt)
        {
            receipt.PrintReceipt();
        }
    }
    public class Basket
    {
        public List<Product> quantity = new List<Product>();
    }
    public class Product
    {
        public string NameOfProduct { get; set; }
        public int PriceOfProduct { get; set; }
        public string TypeOfProduct { get; set; }
    }
    public class Receipt
    {
        public void PrintReceipt()
        {
            Seller sellerInfo = new Seller();
            Buyer buyerInfo = new Buyer();
            Console.WriteLine("The Receipt\n");
            Console.WriteLine($"Seller`s name: {sellerInfo.FirstName}, {sellerInfo.LastName}");
            Console.WriteLine($"Buyer`s name: {buyerInfo.FirstName}, {buyerInfo.LastName}");
        }
    }
    public class Buyer : IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int AccountID { get; set; }
    }
    public class Seller : IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int AccountID { get; set; }
    }
    class Program
    {
        static void Main()
        {

        }
    }
}
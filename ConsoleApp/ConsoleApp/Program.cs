using System;
using System.Text;
using System.IO;
namespace ConsoleApp
{
    //i.safontev/homework/12-abstractions
    #region Internet Shop

    class InternetShop
    {
        public Product[] Products { get; set; }
        public Buyer[] Buyers { get; set; }
        public Staff[] Staff { get; set; }
    }

    class Staff
    {
        private string ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }
        private string Position { get; set;}

    }

    class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CommonCount { get; set; }

    }

    class Buyer
    {
        private string ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }
    }

    class Receipts
    {
        public Buyer Buyer { get; set; }
        public Product Product { get; set; }

    }

    #endregion

    #region Interfaces

    interface IAddBuyer
    {
        void AddNewBuyer(string ID, string FirstName, string LastName, string PhoneNumber);
        void RefreshBuyer();
    }

    interface INewProduct
    {
        void RegistrateNewProduct(string ID, string Name, double Price, int Count);
    }

    interface IAddNProduct
    {
        void AddNProduct(int Count, int n);
    }

    interface ISellProduct
    {
        void SellProduct(int Count, int n);
    }

    #endregion
    class Program
    {
        static void Main()
        {

        }
    }
}
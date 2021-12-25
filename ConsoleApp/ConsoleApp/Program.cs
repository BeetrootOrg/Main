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
    }

    class Product : IAddNProduct, INewProduct, ISellProduct
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CommonCount { get; set; }

        public void AddNProduct(int Count, int n) { }
        public void RegistrateNewProduct(string ID, string Name, double Price, int Count) { }
        public void SellProduct(int Count, int n) { }
    }

    class Buyer : IAddBuyer
    {
        private string ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }

        public void AddNewBuyer(string ID, string FirstName, string LastName, string PhoneNumber) { }
        public void RefreshBuyer() { }
    }

    class Receipts
    {
        public Buyer Buyer { get; set; }
        public Product Product { get; set; }

    }

    #endregion

    #region Interfaces

    public interface IAddBuyer
    {
        void AddNewBuyer(string ID, string FirstName, string LastName, string PhoneNumber);
        void RefreshBuyer();
    }

    public interface INewProduct
    {
        void RegistrateNewProduct(string ID, string Name, double Price, int Count);
    }

    public interface IAddNProduct
    {
        void AddNProduct(int Count, int n);
    }

    public interface ISellProduct
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
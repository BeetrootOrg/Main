using System;
using System.Text;
using System.IO;
namespace ConsoleApp
{
    //i.safontev/homework/12-abstractions
    #region Internet Shop

    public class InternetShop
    {
        public Product[] Products { get; set; }
        public Buyer[] Buyers { get; set; }
    }

    public class Product : IAddNProduct, INewProduct, ISellProduct
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CommonCount { get; set; }

        public void AddNProduct(int n) { CommonCount += n; }
        public Product RegistrateNewProduct(string ID, string Name, double Price, int Count)
        {
            Product newProduct = new Product
            {
                ID = ID,
                Name = Name,
                Price = Price,
                CommonCount = Count,
            };
            return newProduct;
        }
        public void SellProduct(int n) { CommonCount -= n; }
    }

    public class Buyer : IAddBuyer
    {
        private string ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }

        public Buyer AddNewBuyer(string ID, string FirstName, string LastName, string PhoneNumber)
        {
            Buyer newBuyer = new Buyer
            {
                ID = ID,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
            };
            return newBuyer;
        }
    }

    public class Receipts
    {
        public Buyer Buyer { get; set; }
        public Product[] Products { get; set; }

    }

    #endregion

    #region Interfaces

    public interface IAddBuyer
    {
        Buyer AddNewBuyer(string ID, string FirstName, string LastName, string PhoneNumber);
    }

    public interface INewProduct
    {
        Product RegistrateNewProduct(string ID, string Name, double Price, int Count);
    }

    public interface IAddNProduct
    {
        void AddNProduct(int n);
    }

    public interface ISellProduct
    {
        void SellProduct(int n);
    }

    #endregion
    class Program
    {
        static void Main()
        {

        }
    }
}
using System;
using System.Text;
using System.IO;
namespace ConsoleApp
{
    //i.safontev/homework/12-abstractions
    #region Internet Shop

    public class InternetShop : INewProduct, IAddBuyer
    { 
        public Product[] Products { get; set; }
        public Buyer[] Buyers { get; set; }
        public void RegistrateNewProduct(Product newProduct)
        {
            Product[] newProducts = new Product[Products.Length + 1];
            Array.Copy(Products, 0, newProducts, 0, Products.Length);
            newProducts[newProducts.Length - 1] = newProduct;
            Products = newProducts;
        }

        public void AddNewBuyer(Buyer newBuyer)
        {
            Buyer[] newBuyers = new Buyer[Buyers.Length + 1];
            Array.Copy(Buyers, 0, newBuyers, 0, Buyers.Length);
            newBuyers[newBuyers.Length] = newBuyer;
            Buyers = newBuyers;
        }

    }

    public class Product : IAddNProduct, ISellProduct
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CommonCount { get; set; }

        public void AddNProduct(int n) { CommonCount += n; }
        public void SellProduct(int n) { CommonCount -= n; }

        public override string ToString()
        {
            return $" ID= {ID}\n Name= {Name}\n Price= {Price}\n Common Count= {CommonCount}\n";
        }
    }

    public class Buyer
    {
        private string ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }

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
        void AddNewBuyer(Buyer newBuyer);
    }

    public interface INewProduct
    {
        void RegistrateNewProduct(Product newProduct);
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
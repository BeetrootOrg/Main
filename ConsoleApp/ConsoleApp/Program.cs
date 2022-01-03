using System;

namespace ConsoleApp
{
    #region Shop Classes
    public class Shop : ICreateNewProduct, IAddProducts, IRegisterUser, ISellProduct
    {
        public Product[] ProductsList { get; set; }
        public User[] UsersList { get; set; }

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product, int quantity)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(User User)
        {
            throw new NotImplementedException();
        }

        public void SellProduct(Product product, int quantity)
        {
            throw new NotImplementedException();
        }
    }


    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public string Quantity { get; set; }
        public Category ProductCategory { get; set; }

    }
    public class Category
    {
        public string CategoryName { get; set; }
        public string[] CategoryProperties { get; set; }
    }

    public class User
    {
        private string ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private double Email { get; set; }
        private string PhoneNumber { get; set; }
    }
    public class Receipts
    {
        public User User { get; set; }
        public Product[] SoldProducts { get; set; }
    }
    #endregion

    #region Interfaces

    public interface ICreateNewProduct
    {
        void CreateProduct(Product product);
    }
    public interface IAddProducts
    {
        void AddProduct(Product product, int quantity);
    }
    public interface ISellProduct
    {
        void SellProduct(Product product, int quantity);
    }
    public interface IRegisterUser
    {
        void RegisterUser(User User);
    }
    #endregion

    class Program
    {
        static void Main()
        {
        }
    }
}
using System;

namespace ConsoleApp
{
    #region Shop Classes
    public class Shop : ICreateNewProduct, IRegisterUser, IAddProducts, ISellProduct
    {
        public Product[] ProductsList { get; set; }
        public User[] UsersList { get; set; }

        public void CreateProduct(Product newProduct)
        {
            Product[] newProducts = new Product[ProductsList.Length + 1];
            Array.Copy(ProductsList, 0, newProducts, 0, ProductsList.Length);
            newProducts[^1] = newProduct;
            ProductsList = newProducts;
        }

        public void RegisterUser(User newUser)
        {
            User[] newUsers = new User[UsersList.Length + 1];
            Array.Copy(UsersList, 0, newUsers, 0, UsersList.Length);
            newUsers[^1] = newUser;
            UsersList = newUsers;
        }

        public void AddProduct(Product product, int quantity)
        {
            product.Quantity += quantity;
        }

        public void SellProduct(Product product, int quantity)
        {
            product.Quantity -= quantity;
        }
    }


    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
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
        void CreateProduct(Product newProduct);
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
        void RegisterUser(User newUser);
    }
    #endregion

    class Program
    {
        static void Main()
        {
        }
    }
}
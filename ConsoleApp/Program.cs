﻿namespace ConsoleApp
{
    using System;

    class ConsoleApp
    {
        class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public Product(int id, string name, string category, string description, int price)
            {
                this.ID = id;
                this.Name = name;
                this.Category = category;
                this.Description = description;
                this.Price = price;
            }
        }
        class Cart
        {
            public int ID { get; set; }
            public Product[] product { get; set; }
            public int TotalPrice;
        }
        class Payement
        {
            int BuyerID;
            string Name;
            // int Cart
        }
        interface IProduct
        {
            void AddProduct(int ID, string name, string Category, string Description, int Price);
            public void EditProduct(ref Product product, int id, string name, string category, string description, int price);
            bool DeleteProduct(ref Product product, int ID);
        }
        interface IProductShow
        {
            void ShowProduct(Product product);
        }
        class Admin : IProduct, IProductShow
        {
            int ID;
            string Name;
            private Product [] _product;
            public Admin(int id, string name)
            {
                this.ID = id;
                this.Name = name;
            }
            public void InitProductDateBase(Product [] prduct)
            {
                _product = prduct;
            }
            public void AddProduct(int id, string name, string category, string description, int price)
            {
                _product[id] = new Product(id, name, category, description, price);
            }

            public void EditProduct(ref Product product, int id, string name, string category, string description, int price)
            {
                product.ID = id;
                product.Name = name;
                product.Category = category;
                product.Description = description;
                product.Price = price;
            }

            public bool DeleteProduct(ref Product product, int ID)
            {
                return true;
            }

            public void ShowProduct(Product product)
            {
                throw new NotImplementedException();
            }
        }
        class Buyer : IProductShow
        {
            int _id;
            string _name;
            Cart _cart;
            public Buyer(int id, string name)
            {
                this._id = id;
                this._name = name;
            }
            public void ShowProduct(Product product) {/*To Do*/ }
            public void AddProductToCart(Product product) {/*To Do*/ }
            public void DeleteProductFromCart(int id) {/*To Do*/ }

        }
        class InternetShop
        {
            private const int _maximumNumberOfProducts = 3;
            private Product[] _products { get; set; }
            public Admin Admin { get; set; }
            public Buyer[] buyers { get; set; }
            public InternetShop()
            {
                _products = new Product[_maximumNumberOfProducts];
            }
            public Product[] EnableDataBaseForAdmin(Admin admin)
            {
                if (this.Admin == admin)
                {
                    return _products;
                }
               else
                {
                    throw (new Exception("You do not have permission!"));
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/13-InternetShop \r\n");

            InternetShop CarShop = new InternetShop();
            Admin admin = new Admin(0, "admin");
            CarShop.Admin = admin;
            admin.InitProductDateBase(CarShop.EnableDataBaseForAdmin(CarShop.Admin));
            CarShop._products[0] = new Product(0, "Ford", "Car", "good car", 10000);
            CarShop._products[1] = new Product(0, "Opel", "Car", "good car", 12000);
            CarShop._products[2] = new Product(0, "Renault", "Car", "good car", 15000);
        }
    }
}

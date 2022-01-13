using System;
using System.Linq;
using System.Collections.Generic;
namespace ConsoleApp1
{

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quainity { get; set; }

        public Product(int id, string name, string Description, double Price, int Quainity)
        {
            this.Id = id;
            this.Name = name;
            this.Description = Description;
            this.Price = Price;
            this.Quainity = Quainity;
        }
   
        }

    
    interface IProduct
    {
        public void AddProduct(ref Product product);
        public void EditProduct(ref Product product, int id, string name, string description, double price, int quainity);
        public void DeleteProduct(ref Product product, int ID);
    }
    interface IShowProducts
    {
        void ShowProduct();
    }
    class Basket
    {
        public int BasketId { get; set; }
        public Product product { get; set; }
        public double TotalPrice { get; set; }

    }
    class Admin : IProduct, IShowProducts
    {

        public List<Product> product=new List<Product>();

        int ID { get; set; }
        string Name { get; set; }
        public Admin(int Id, string name)
        {
            this.ID = Id;
            this.Name = name;

        }

        public void AddProduct(ref Product products)
        {
            product.Add(products);
                  
        }
        public void EditProduct(ref Product product, int id, string name, string description, double price, int quainity)
        {
            product.Id = id;
            product.Name = name;
            product.Description = description;
            product.Price = price;
            product.Quainity = quainity;

        }
        public void DeleteProduct(ref Product product, int id)
        {
            product = null;
        }
        public void ShowProduct()
        {       
            foreach(Product pr in product)
            {
              
                Console.Write("Id: {0}, ", pr.Id);
                Console.Write("Name: {0}, ", pr.Name);
                Console.Write("Description: {0}, ", pr.Description);
                Console.Write("Price: {0}, ", pr.Price);
                Console.Write("Quantity: {0}\r\n", pr.Quainity);
            }
            
        }

    }




    class Program
    {
        static void Main()
        {

            var potate = new Product(1, "potato", "tasty", 22.5, 1);
            var abrikos = new Product(1, "abrikos", "nyam", 11, 2);
            var adm = new Admin(1, "ss");
            adm.AddProduct(ref potate);  
            adm.AddProduct(ref abrikos);
            adm.ShowProduct();
        }
    }


}

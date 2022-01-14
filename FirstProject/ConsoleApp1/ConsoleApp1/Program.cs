using System;
using System.Linq;
using System.Collections.Generic;
namespace ConsoleApp1
{
 
    interface IProduct
    {
        public void AddProduct(ref Product product);
        public void EditProduct(ref Product product, int id, string name, string description, double price, int quainity);
        public void DeleteProduct(ref Product product, int id);
    }
    interface IShowProducts
    {
        void ShowProduct();
    }
    interface IBuyer
    {
        void AddProductInBakset(ref Product product);
        void DeleteFromBasket(ref Product product);
        void GetRecipe();

    }

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
    class Buyer:IBuyer,IShowProducts
        
    {
        public List<Product> buyersProducts = new List<Product>();
        //
     
        public Buyer(string name,int id)
        {
            this.Name=name;
            this.Id=id;
        }

        public string Name { get; set; }   
        public int Id   { get; set; }

        public void AddProductInBakset(ref Product product)
        {
            buyersProducts.Add(product);
        }

        public void DeleteFromBasket(ref Product product)
        {
           buyersProducts.Remove(product);
        }

        public void GetRecipe()
        {

            double result = 0;
            foreach (Product p in buyersProducts)

            {
                Console.WriteLine($"Name product: {p.Name}\t Price: {p.Price}"); 
                result += p.Price;

            }
            Console.WriteLine($"Total price in recipe: { result}");
            Console.WriteLine($"Time of purchase: { DateTime.Now }");
           
        }
       
        public void ShowProduct()
        {

            foreach (Product pr in buyersProducts)
            {

                
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

            var potate = new Product(1, "potato", "tasty", 10, 1);
            var abrikos = new Product(1, "abrikos", "nyam", 20, 2);
            //
            var adm = new Admin(1, "ss");
            //
            var buyer1 = new Buyer("Vasil", 2);

            buyer1.AddProductInBakset(ref potate);
            buyer1.AddProductInBakset(ref abrikos);
            buyer1.GetRecipe();
       
        }
    }


}

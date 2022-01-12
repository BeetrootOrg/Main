using System;

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
        public void AddProduct(int Id, string name, string description, double price, int quainity);
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
        public Product[] _product;
        int ID { get; set; }
        string Name { get; set; }
        public Admin(int Id, string name)
        {
            this.ID = Id;
            this.Name = name;

        }

        public void AddProduct(int id, string name, string description, double price, int quainity)
        {
            _product[id] = new Product(id, name, description, price, quainity);

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
            if (_product != null)
            {
                for (int i = 0; i < _product.Length; i++)
                {

                    Console.Write("Id: {0}, ", _product[i].Id);
                    Console.WriteLine("Name: {0}", _product[i].Name);
                    Console.WriteLine("Description: {0}", _product[i].Description);
                    Console.WriteLine("Price: {0}", _product[i].Price);
                    Console.WriteLine("Quanity: {0}", _product[i].Quainity);
                }

            }
            else
            {
                Console.WriteLine("Not found any product");
            }
        }

    }




    class Program
    {
        static void Main()
        {
            var potate = new Product(1, "potato", "tasty", 22.5, 1);
            var adm = new Admin(1, "ss");
            adm.AddProduct(1, "potato", "tasty", 22.5, 1);
            adm.ShowProduct();
        }
    }


}

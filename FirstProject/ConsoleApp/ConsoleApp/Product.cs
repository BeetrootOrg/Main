using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    public class Product
    {
        List<Product> products = new List<Product>();
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product()
        {
        }
        public Product(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
        public void CreateProducte()
        {
            Console.WriteLine("Введите название продукта: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите описание продукта: ");
            string description = Console.ReadLine();
            Console.WriteLine("Введите цену продукта: ");
            double price = Console.ReadLine().Length;
            products.Add(new Product(name, description, price));
            Console.WriteLine("Продукт добавлен");
        }

        public void ShowAllProducts()
        {
            int num = 1;
            foreach (Product p in products)
            {
                Console.WriteLine($"{num} продукт: \n Имя продукта: {p.Name}\n Описание продукта: {p.Description}\n Цена продукта: {p.Price}\n");
                num++;
            }
        }
    }
}

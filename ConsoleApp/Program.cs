using System;

namespace ConsoleApp

{
    public class Receipt
    {
        string ID { get; init; }
        Product product;
        Buyer buyer;
        DateTime DateOfPurchase { get; set; }

    }

    class Buyer
    {
        private int id; 
        int ID { get; init; }
        string Name { get; init; }
        string Adress { get; init; }
        byte LevelOfPrivilege { get; set; }
        int TotalPurchase { get; set; }

        public Buyer AddBuyer(string Name, string Adress, int TotalPurchase,byte LevelOfPrivilege=0) => new()
        {
            ID = +id,
            Name= Name,
            Adress= Adress,
            TotalPurchase= TotalPurchase,
            LevelOfPrivilege = LevelOfPrivilege,

        };

    }

    class Product
    {

        public int ID { get; init; }
        public string Name { get; set; }
        public DateTime Created { get; init; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }



        public Product Prototype() => new()
        {

            ID =+ ID,
            Name = Name,
            Created = Created,
            ExpireDate = ExpireDate,
            Quantity = Quantity,
            Price = Price,
        };

        private Product UpdatePrice(Product product, int price)
        {
            if (price == product.Price) Console.WriteLine("Price didn't change");
            else product.Price = price;
            return product;
        }

        private Product UpdateQuantity(Product product, int quantity)
        {
            if (quantity == product.Quantity) Console.WriteLine("Quantity didn't change");
            else product.Quantity = quantity;
            return product;
        }

        private Product SellProduct(Product product, int sellQuantity)
        {
            if (sellQuantity > product.Quantity) throw new ArgumentException("Can't sell more than you have");
            else UpdateQuantity(product, product.Quantity - sellQuantity);
            return product;
        }
    }
    class ProductCreate
    {
        private string _name;
        private int id;
        private decimal _price;
        private int _quantity;

        public ProductCreate SetName(string Name)
        {
            if (_name == null)
            {
                _name = Name;
            }
            else
            {
                throw new ArgumentException("Name already exist");
            }
              
                
            return this;
        }

        public ProductCreate SetPrice(decimal Price)
        {
            if (_price <= 0)
            {
                _price = Price;
            }
            else
            {
                throw new ArgumentException("Price to low");
            }
            return this;
        }
        public ProductCreate SetQuantity(int Quantity)
        {
            if (Quantity > 0)
            {
                _quantity = Quantity;
            }
            else _quantity = 0;

            return this;
        }

        public Product Create()
        {

            return new Product
            {
                ID = ++id,
                Name = _name,
                Created = DateTime.Now,
                ExpireDate = DateTime.Now.AddDays(360),
                Quantity = _quantity,
                Price = _price,
            };
        }
    }
    

    public class InternetShop
        {
            Product[] products;
            Buyer[] buyers;
            Receipt[] receipts;

        }

        public class Program

        {
            static void Main()

            {
                var product = new ProductCreate()
                    .SetName("SomeProdName")
                    .SetPrice(12.1m)
                    .Create();

            Console.WriteLine(product.Name);

            var product12 = product.Prototype();
            Console.WriteLine(product12.ID);
            product12.Price = 21.1m;

            }
        }
    
}

using System;
using System.IO;

namespace ConsoleApp
{
    
    interface IBuyers
    {
        string FullName (string firstName, string lastName);
        int Age { get; set; }
        string Sex { get; set; }
        int Id { get; }
        string Adress { get; set; }
        string Email { get; set; }

    }
    interface IAdmin:IBuyers
    {        
        string EmployeePosition { get; set; }
        void CreateProduct(string productName, double Price);
    }

    interface Archive: IProduct
    {
       string Archive { get; set; }
       string SerchByName();
    }

    interface IProduct : IPrice
    {
        int Scu { get; }
        string Name { get; set; }
        string Discription { get; set; }
        int Amount { get; set; }   
        
        bool StockStatus()
        {
            bool StockStatus = false;
            if (Amount > 0)
            {
                StockStatus = true;
            }
            else
            {
                StockStatus = false;
            }
            return StockStatus;
        }
    }

    

    interface IPrice
    {
        double ProductPrice(double oldPrice, double discount);
    }
    
    class Price : IPrice
    {
       double discountPrice = 0;
       public double ProductPrice(double oldPrice, double discount)
        
        {
            if (discount > 0 && discount <=99)
            {
                discountPrice = oldPrice * (discount/100);
            }
            else
            {
                discountPrice = oldPrice;
            }
            return discountPrice;
        }
             
    }

    class User: IBuyers
    {
        public string FullName(string firstName, string lastName) => $"{firstName} {lastName}";
        
        public int Age { get; set; }
        public string Sex { get; set; }
        public int Id { get; init; }
        public string Adress { get; set; }
        public string Email { get; set; }

    }

    class ArchiveSCU : Archive
    {
        const string Data = "archive.csv";

        private void ArchiveData() => File.AppendAllLines(Data, contents: new[] { $"{IProduct.Name} , {IProduct.Scu}" });

        private static (string, string)[] ReadArchive()
        {
            string[] lines = File.ReadAllLines(Data);

            var archive = new (string, string)[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(',');
                archive[i - 1] = (splitted[0], splitted[1]);
            }

            return archive;

        }

        private void SerchByName()
        {
            SerchByName(IProduct);
        }

        void SerchByName(IProduct name)
        {
            string searchTerm = name;

            bool found = false;
            foreach (var (IProduct.Name, IProduct.Scu) in Data())
            {
                if (IProduct.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) 
                {
                    return;
                }
            }

            if (!found)
            {
                
            }
        }
    }
    

    class Program
    {        
        
        static void Main()
        {
            Price product = new Price();
            Console.WriteLine(Price(product,10,70));
        }

        static double Price(IPrice price, double oldPrice, double discount) => price.ProductPrice(oldPrice, discount);
        
    }
}
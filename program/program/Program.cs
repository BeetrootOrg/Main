using System;
using System.IO;

namespace ConsoleApp
{
    interface IPrice
    {
        double ProductPrice(double i1);
        double Discount(double i2);
    }
        
    interface IQuantity
    {
        string AmountOfProduct (string i1);

        bool Availablilty();
    }

    interface IID
    {
        int Gtin13(int i1);
        int Mpn(int i1);
        int Scu(int i1);
    }
    interface IName
    {
        string NameOfTheProduct(string i1);
        string Brand (string i1);
       
    }

    class Product : IPrice, IQuantity, IID, IName
    {
        public double ProductPrice(double price) => price;
        public double Discount(double discount) => discount;
        public string AmountOfProduct (string product) => product;
        public bool Availablilty() => true;
        public int Gtin13(int i1) => throw new NotImplementedException();
        public int Mpn(int i1) => throw new NotImplementedException();
        public int Scu(int i1) => throw new NotImplementedException();
        public string NameOfTheProduct(string i1) => throw new NotImplementedException();
        public string Brand(string i1) => throw new NotImplementedException();

        string discription();

    }
    class Program
    {        
        static void Main()
        {
            
            
        }

        
    }
}
using System;
using System.IO;

namespace ConsoleApp
{
    //const string Filename = @"discription.csv";

    interface IPrice
    {
        double ProductPrice(double oldPrice, double discount);
                
    }
    
    interface IAmountOfProduct
    {
        int AmountOfProduct(int amountOfProdut);
    }
    interface IStockStatus
    {
        string StockStatus(string Stock);
    }

    interface IID
    {
        int Gtin13(int Gtin13);
        int Mpn(int Mpn);
        int Scu(int Scu);
    }
    interface IName
    {
        string NameOfTheProduct(string NameOfTheProduct);
        string Brand (string BrandName);
       
    }

    class Product : IPrice
    {
        double discountPrice;
       public double ProductPrice(double oldPrice, double discount)
        //=> oldPrice * discount;
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

    class Availability : IAmountOfProduct
    {

        public int AmountOfProduct(int amountOfProdut)
        {
            string stockStatus;

            
            return amountOfProdut;
        }
    }

    class StockStatus : Availability, IStockStatus
    {
        string IStockStatus.StockStatus(string Stock)
        {
            throw new NotImplementedException();
        }
    }

    //class Specs : IName, IID, IPrice
    //{
    //    public string Brand(string BrandName)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public string NameOfTheProduct(string NameOfTheProduct)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}


    class Program
    {        
        static void Main()
        {
            Product product = new Product();
            Availability availability = new Availability(); 
            Console.WriteLine(Price(product,10,70));
            Console.WriteLine(Availability(availability,10));

            
        }

        static double Price(IPrice price, double oldPrice, double discount) => price.ProductPrice(oldPrice, discount);
        static double Availability(IAmountOfProduct availability, int amountOfProdut) => availability.AmountOfProduct(amountOfProdut);
    }
}
using System;
using System.Text;
using System.IO;
namespace ConsoleApp
{
    //i.safontev/homework/12-abstractions
    /*
    Опишите с помощью UML-домена "интернет-магазин".
    Он должен включать продукты (с указанием цены, количества и т. Д.),
    Покупателей (личная информация),
    квитанции (что и кому было продано) и т. Д.

    Реализуйте все сущности в программе C #

    Предоставьте консольный интерфейс для регистрации нового продукта,
    добавления количества к существующему, продажи продукта, регистрации покупателя.
    */
    #region Internet Shop

    class InternetShop
    {
        public Product[] Products { get; set; }
        public Buyer[] Buyers { get; set; }
        public Staff[] Staff { get; set; }
    }

    class Staff
    {
        private string StaffID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }
        private string Position { get; set;}

    }

    class Product
    {
        public string ProductID { get; set; }
        public double Price { get; set; }
        public int CommonCount { get; set; }

    }

    class Buyer
    {
        private string BuyerID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }
    }

    class Receipts
    {
        public Buyer Buyer { get; set; }
        public Product Product { get; set; }

    }

    #endregion

    #region Interfaces

    interface IBuyer
    {
        void AddNewBuyer();
        void RefreshBuyer();
    }

    interface INewProduct
    {
        void AddNewProduct();
    }

    interface IAddProduct
    {

    }

    interface ISellProduct
    {

    }

    #endregion
    class Program
    {
        static void Main()
        {

        }
    }
}
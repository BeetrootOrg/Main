using System;

namespace ConsoleApp
{
    public class Program
    {
        interface IUserAccount
        {
            void ChangeFullName(string OldFullName, string NewFullName);
            void ChangePhoneNumber(double OldPhoneNumber, double NewPhoneNumber);

        }
        class InternetShop
        {
            Product[] Products;
            private Seller[] Sellers;
            private Buyer[] Buyers;
            private Order[] Orders;
            public class User
            {
                int ID;
                string FullName;
                string PhoneNumber;

            }
            public class Buyer : User
            {
                decimal CardBalance;
                string FullName;
                string PhoneNumber;
                public Buyer(int id, string fullName, string phoneNumber, decimal cardBalance)
                {
                    FullName = fullName;
                    PhoneNumber = phoneNumber;
                    CardBalance = cardBalance;
                }
            }
            public class Seller : User
            {
                string LegalAddress;
            }
            class Order
            {
                int ID;
                ElementaryOrder[] ElOrders;
                DateTime ReceiptDateTime;
                DateTime FullfilmentDateTime;
                Buyer buyer;
                class ElementaryOrder
                {
                    Product product;
                }
            }


        }



        public class Product
        {
            public Product(int id, string name, InternetShop.Seller seller, decimal price, int qty)
            {
                ID = id;
                Name = name;
                Seller = seller;
                Price = price;
                Qty = qty;
            }

            public string Name { get; set; }
            public InternetShop.Seller Seller { get; set; }
            public decimal Price { get; set; }
            public int Qty { get; set; }
        }

        class Personal
        {
            public Personal(string firstName, string lastName, string phoneNumber)
            {
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
            }

            public string FirstName { get; init; }
            public string LastName { get; init; }
            public string FullName => $"{FirstName} {LastName}";
            public string PhoneNumber { get; set; }

        }





        static void Main()
        {

        }
    }
}

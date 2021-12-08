using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DeliveryAdress { get; set; } 
        public Basket[] Baskets { get; set; }

        public Book[] Books { get; set; }
        public int ID { get; set; }
        public void NewBasket()
        {

        }
    }
}

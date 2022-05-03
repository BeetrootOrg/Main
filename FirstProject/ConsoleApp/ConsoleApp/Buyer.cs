using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp
{
    public class Buyer
    {
        List<Buyer> buyers = new List<Buyer>();
        public Buyer(string name, int idBuyer, string password)
        {
            Name = name;
            IdBuyer = idBuyer;
            Password = password;
        }
        public Buyer()
        {

        }
        public string Name { get; set; }
        private int IdBuyer { get; set; }
        private string Password { get; set; }

        public void CreateBuyer()
        {
            Console.WriteLine("Введите имя покупателя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите свой Id: ");
            int idBuyer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите пароль покупателя: ");
            string password = Console.ReadLine();
            buyers.Add(new Buyer(name, idBuyer, password));
            Console.WriteLine("Покупатель создан");
        }
        public void GoShopping()
        {
            Console.WriteLine("Choose product");

            




            Basket tempBasket = new Basket();

        }

    }
}

using ConsoleAppHomework13Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces
{
    public class InternetShop : IInternetShop
    {
        private List<IProduct> _products { get; set; }
        private List<IClient> _clients { get; set; }
        private List<ICheck> _checks { get; set; }
        private IClient _current { get; set; }
        private List<IProduct> _basket { get; set; }
        private int _balance { get; set; }

        public InternetShop()
        {
            _products = new List<IProduct>();
            _clients = new List<IClient>();
            _checks = new List<ICheck>();
            _basket = new List<IProduct>();
            _balance = 0;
        }

        public void MainMenu()
        {
            bool work = true;
            while (work)
            {
                if (_current == null)
                {

                    Console.WriteLine("Press 1 to Register");
                    Console.WriteLine("Press 2 to Login");
                    Console.WriteLine("Press 3 to Exit");

                    string temp = Console.ReadLine();
                    switch (temp)
                    {
                        case "1":
                            Registration();
                            break;
                        case "2":
                            _current = Login();
                            break;
                        case "3":
                            work = false;
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                }
                else if (_current != null)
                {
                    Warning("Insert 1 to add product");
                    Warning("Insert 2 to add check");
                    Warning("Insert 3 to look it all");


                    string temp = Console.ReadLine();

                    switch (temp)
                    {
                        case "1":
                            AddProduct();
                            break;
                        case "2":
                            AddCheck();
                            break;
                        case "3":
                            LookAllProduct();
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                }
            }
        }

        private void LookAllProduct()
        {
            foreach (var item in _products)
            {
                Console.WriteLine($"Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Price: {item.Price}\n");
            }
            Console.ReadKey();
        }

        private int CountOfSum()
        {
            int sum = 0;
            for (int i = 0; i < _basket.Count; i++)
            {
                sum += _basket[i].Price;
            }
            return sum;
        }
        private void AddCheck()
        {
            int sum = CountOfSum();
            _balance += sum;
            _current.Balance -= sum;
            _checks.Add(new Check(_current, _basket, DateTime.Now, CountOfSum()));
            _basket.Clear();
        }
        private void Registration()
        {
            Warning("Name");
            string name = Console.ReadLine();
            
            Warning("Password");
            string password = Console.ReadLine();
            
            Warning("Confirm Password");
            string confirmPassword = Console.ReadLine();
            if (password == confirmPassword)
            {
                _clients.Add(new Client(name, 100, password));
                Success("User successfully registered");
            }
            else
            {
                Error("Passwords doesn't match");
            }

            Console.Clear();
        }

        private IClient Login()
        {
            Warning("Write login");
            string login = Console.ReadLine();
            Warning("Write password");
            string password = Console.ReadLine();
            var user = GetClient(login, password);
            if (user == null)
            {
                Error("User not found");
                return null;
            }
            return user;
        }
        
        private IProduct AddProduct()
        {
            Console.Clear();
            Warning("Insert data of product pleace");
            Warning("Insert name of product");
            string name = Console.ReadLine();
            Warning("Insert price of product");
            int price = NumberInput(Console.ReadLine());
            Warning("Insert description of product");
            string description = Console.ReadLine();
            var beetroot = new Product(name, price, description);
            _products.Add(beetroot);
            return beetroot;
        }

        private ICheck GetCheck()
        {
            try
            {
                Console.Clear();
                Warning("Insert Id please");
                int id = NumberInput(Console.ReadLine());
                foreach (var item in _checks)
                {
                    if (item.Id == id) return item;
                }
                throw new ArgumentException("Item not found");
            }
            catch (ArgumentException ex)
            {
                Error(ex.Message);
                return GetCheck();
            }
        }

        private IClient GetClient()
        {
            try
            {
                Console.Clear();
                Warning("Insert Id pleace");
                int id = NumberInput(Console.ReadLine());
                foreach (var item in _clients)
                {
                    if (item.Id == id) return item;
                }
                throw new ArgumentException("Item not found");
            }
            catch (ArgumentException ex)
            {
                Error(ex.Message);
                return GetClient();
            }
        }

        private IClient GetClient(string login, string password)
        {
            Console.Clear();
            foreach (var item in _clients)
            {
                if (item.Name == login && item.Password == password) return item;
            }
            return null;
        }

        private IProduct GetProduct()
        {
            try
            {
                Console.Clear();
                Error("Insert Id pleace");
                int id = NumberInput(Console.ReadLine());
                foreach (var item in _products)
                {
                    if (item.Id == id) return item;
                }
                throw new ArgumentException("Item not found");
            }
            catch (ArgumentException ex)
            {
                Error(ex.Message);
                return GetProduct();
            }
        }

        protected void Success(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected void Error(string text)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        protected void Warning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected void BlockTerminal()
        {
            Warning("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        protected int NumberInput(string text)
        {
            try
            {
                return int.Parse(text);
            }
            catch (Exception)
            {
                Error("Wrong input");
                Warning("Please try again");
                return NumberInput(Console.ReadLine());
            }
        }
    }
}

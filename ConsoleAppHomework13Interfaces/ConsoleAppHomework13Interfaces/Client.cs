using ConsoleAppHomework13Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces
{
    public class Client: IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Password { get; set; }
        public Client(string name, int balance, string password)
        {
            Name = name;
            Balance = balance;
            Password = password;
        }

    }
}

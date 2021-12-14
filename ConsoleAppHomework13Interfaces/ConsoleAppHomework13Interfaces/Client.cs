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
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int Id { get; set; }

    }
}

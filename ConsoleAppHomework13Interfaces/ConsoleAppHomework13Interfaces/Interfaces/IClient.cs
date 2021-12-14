using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces.Interfaces
{
    internal interface IClient
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int Id { get; set; }
    }
}

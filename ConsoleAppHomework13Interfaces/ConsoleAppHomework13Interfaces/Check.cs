using ConsoleAppHomework13Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces
{
    public class Check: ICheck
    {
        public Client Client { get; set; }
        public List<Product> Products { get; set; }
        public int Date { get; set; }
        public int Id { get; set; }


    }
}

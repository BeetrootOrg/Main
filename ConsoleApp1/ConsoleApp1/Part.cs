using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Part
    {
        public string Name { get; set; }
        public Part CreateNew()
        {
            return new Part();
        }
    }
}

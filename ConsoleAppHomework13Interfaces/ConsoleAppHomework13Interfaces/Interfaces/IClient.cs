using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces.Interfaces
{
    public interface IClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Password { get; set; }
    }
}

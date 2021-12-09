using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomeworkOOP
{
     class Contract
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public List<Book> Books { get; set; }
        public decimal Sum { get; set; }


    }
}

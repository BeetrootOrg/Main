using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomeworkOOP
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public int CountOfPages { get; set; }
        public decimal Price { get; set; }


    }
}

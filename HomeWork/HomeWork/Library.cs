using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public static class Library
    {
        public static List<Author> authors = new List<Author>();
        public static List<Book> books = new List<Book>();
        public static List<Customer> customer = new List<Customer>();
        public enum SearchBy
        {
            Author,
            BookName
        }

        public static Book search(SearchBy searchBy, string value)
        {
            return null;
        }
    }
}

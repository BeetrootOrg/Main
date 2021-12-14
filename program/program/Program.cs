using System;
using System.IO;

namespace ConsoleApp
{
    class Library
    {
        public string Name;
    }

    class Visitors
    {
        private int BirthDay { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    class VisitorsTiket
    {
        private string Name { get; set; }
        private int DateWhenTakeTheBook { get; set; }
        public int NameOfTheBook { get; set; }
        private int DateOfValidationTiket { get; set; }
        private object Stamp { get; init; }
        private object Sign { get; init; }

    }

    class Archive
    {
        public string NameOfBooks { get; init; }
        public string AuthorOfBooks { get; init; }

        public bool Availability { get; set; } //InStock, OutOfStock

        public string VisitorsTiket { get; set; }
    }

    class BookShelves
    {
        private string Alphabeticality { get; set; }
        private int Shelves { get; set; }

    }

    class Shelves
    {
        public string Books { get; set; }
        private string Alphabeticality { set; get; }
    }

    class Books
    {
        public string Name { get; init; }
        public string AuthorName { get; init; }
        public int NumOfThePage { get; init; }
        public string Content { get; init; }
    }

    class Program
    {        
        static void Main()
        {
            
            
        }

        
    }
}
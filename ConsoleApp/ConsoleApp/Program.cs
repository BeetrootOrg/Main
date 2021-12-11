using System;
using System.Text;
using System.IO;
namespace ConsoleApp
{
    //i.safontev/homework/09-oop
    class BookLibrary
    {
        private Client[] Clients { get; set; }
        private Book[] Books { get; set; }
        private Librarian[] Librarians { get; set; }

    }
    class Librarian
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }
        private int WorkExperience { get; set; }
        private double Salary { get; set; }

    }
    class Client
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string ClientID { get; set; }
        private Book[] BorrowedBooks { get; set; }

    }
    class Book
    {
        private string Name { get; set; }
        public string BookID { get; set; }
        public Author WrittenBy { get; set; }
        private string Year { get; set; }
        private string Genre { get; set; }
        private bool IsTaken { get; set; }
        private Client ByWho { get; set; }

    }
    class Author
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }

    }

    class Program
    {
        static void Main()
        {

        }
    }
}

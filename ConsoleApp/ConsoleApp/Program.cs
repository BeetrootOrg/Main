using System;

namespace ConsoleApp
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string ID { get; set; }
    }
    class Book
    {
        public string Author { get; set; }
        public string Genre { get; set; }
    }
    class Genre
    {
        public string GenreName { get; set; }
    }
    class Author
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class UserAccount
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        static void Main()
        {
        }
    }
}
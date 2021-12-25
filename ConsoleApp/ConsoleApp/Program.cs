using System;
namespace ConsoleApp
{
    enum Genre
    {
        Detective,
        Fantasy,
        Horror,
        Other,
    }

    class Library
    {
        public int BookShelf { get; set; }
        public int Visitor { get; set; }
        public Staff Staff { get; init; }
    }
    class Visitor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; init; }
        public Genre FavGeneres { get; set; }
    }
    class Staff
    {
        public Librarian Librarian { get; set; }
        public SecurityGuard SecurityGuard { get; set; }
        public Cleaner Cleaner { get; init; }
    }
    class Cleaner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; init; }
        public int Payment{ get; set; }
    }
    class SecurityGuard
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; init; }
        public int Payment { get; set; }
    }
    class Librarian
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; init; }
        public int Payment { get; set; }
    }
    class BookShelf
    {
        public Book Book { get; set; }
        public string GenrePointers { get; set; }
    }
    class Book
    {
        public Genre Genere { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
    }
}
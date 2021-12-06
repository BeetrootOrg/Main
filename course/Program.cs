using System;
namespace Course
{
    enum Genre
    {
        Other,
        Detective,
        Adventure,
        Horror,
    }

    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; init; }
        public DateTime DeathDate { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public Author Author { get; init; }
        public Genre Genre { get; set; }
        public LibraryUser TakenBy { get; set; }
    }

    class BookInUse
    {
        public DateTime BorrowedDate { get; init; }
        public DateTime DateToReturn { get; set; }
        public Book TakenBook { get; set; }
    }

    class LibraryUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMembershipActive { get; set; }
        public BookInUse[] BooksInUse { get; set; }
    }

    class BookLibrary
    {
        public Book[] Books { get; set; }
        public LibraryUser[] LibraryUsers { get; set; }
    }
}

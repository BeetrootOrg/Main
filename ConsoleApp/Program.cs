namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        enum Category
        {
            Classic,
            History,
            Fantasy
        }
        class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        class BookAuthor
        {
            public Name AuthorName { get; set; }
            public DateTime BirthDay { get; set; }
        }
        class Book
        {

            public BookAuthor bookAuthor { get; set; }
            public string BookTitle { get; set; }
            public Category category { get; set; }
        }
        class VisitHistory
        {
            public DateTime StartReadTime { get; set; }
            public DateTime FinishReadTime { get; set; }
            public Book ReadBooks { get; set; }
        }
        class BookRead
        {
            public Book Reading { get; set; }
            public DateTime StartReadTime { get; set; }
        }
        class Visitor
        {
            public Name ReaderName { get; set; }
            private VisitHistory[] History;
            public BookRead BookReadingNow { get; set; }
            public void AddBookToHistory(Book book) { }
            public void ShowHistory(DateTime from, DateTime to) { }
        }
        class Library
        {
            public static int TotalNumberOfBooks { get; private set; }
            public static int TotalVisitors { get; private set; }
            public static int TotalWriters { get; private set; } 
            private Book[] _books;
            private Visitor[] _activeVisitors;

            static Library()
            {
                TotalNumberOfBooks = 0;
                TotalVisitors = 0;
                TotalWriters = 0;
            }
            public void AddNewBook(Book newBook) { }
            public void EditBook(Book editBook) { }
            public void RemoveBook(Book removeBook) { }
            public void ShowBook(Name authorName) { }
            public void AddNewVisitor(Name newVisitor) { }
            public void EditVisitor(Name editVisitor) { }
            public void RemoveVisitor(Name removeVisitor) { }
            public void ShowVisitorReadBooks(Name visitorName) { }
            public void GiveBookToVisitor(Name visitorName, Book book) { }
            public void GetBookFromVisitor(Name visitorName, Book book) { }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/10-Bool-Library \r\n");

            Library BookLibrary = new Library();

            BookLibrary.AddNewBook(new Book() { 
                bookAuthor = { AuthorName = { FirstName = "Leo", LastName = "Tolstoy" }, BirthDay = new DateTime(1828, 5, 23) },
                BookTitle = "War and Peace", 
                category = Category.Classic });
            BookLibrary.AddNewBook(new Book() { 
                bookAuthor = { AuthorName = { FirstName = "Theodor", LastName = "Mommsen" }, BirthDay = new DateTime(1817, 11, 30) }, 
                BookTitle = "Roman history", 
                category = Category.History });
            BookLibrary.AddNewBook(new Book() { 
                bookAuthor = { AuthorName = { FirstName = "Ray Douglas", LastName = "Bradbury" }, BirthDay = new DateTime(1920, 8, 22) }, 
                BookTitle = "The Martian Chronicles", 
                category = Category.Fantasy });

            BookLibrary.AddNewVisitor(new Name() { FirstName = "Petr", LastName = "Ivanov"});
            BookLibrary.AddNewVisitor(new Name() { FirstName = "Ivan", LastName = "Petrov" });

        }
    }
}

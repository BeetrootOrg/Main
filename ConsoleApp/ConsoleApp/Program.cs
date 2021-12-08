using System;

namespace ConsoleApp
{
    public class Library
    {
        Book[] Books { get; set; }
        Reader[] Readers { get; set; }
        Personal[] Personal { get; set; }
        Department[] Departments { get; set; }
    }
    public class Department
    {
        string Name { get; set; }
        Personal[] Personal { get; set; }
        Book[] Books { get; set; }
    }

    public class Personal
    {
        string FirstName { get; init; }
        string LastName { get; init; }
        string FullName => $"{FirstName} {LastName}";
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string Adress { get; set; }
        string Position { get; set; }
        string DepartmentName { get; set; }

    }
    class Book
    {
        string Title { get; init; }
        string AuthorFirstName { get; init; }
        string AuthorLastName { get; init; }
        string Author => $"{AuthorFirstName} {AuthorLastName}";
        bool IsRere { get; init; }
        bool IsForPublicUse { get; set; }
        string InWhoseUse { get; set; }
    }

    class Reader
    {
        string FirstName { get; init; }
        string LastName { get; init; }
        string FullName => $"{FirstName} {LastName}";
        string PhoneNumber { get; set; }
        string Email { get; set; }
        Book[] UsingBooksNow { get; set; }
        Book[] History { get; set; }
        bool IsInBlackList { get; set; }
    }

    public class Program
    {
        static void Main()
        {
            
        }           
    }
}
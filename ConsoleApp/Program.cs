using System;

namespace ConsoleApp
{
    enum Genre
    {
        Scifi,
        Fantasy,
        Pulpfiction,
        Documentary,
        Historical,
        Detective,
        Horror,
        Triller
    }

    class Author
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string FullName => $"{FirstName} {LastName}";
        public int DayOfBirth { get; init; }
        public bool IsAlive { get; set; }
        public int DayOfDeath { get; set; }
    }

    class Book
    {
        public int ISBN { get; init; }
        public string NameOfBook { get; set; }
        public int DateOfCreating { get; init; }
        public int[] DateOfPublication { get; set; }
        public int CounsOfCopyInLibrary { get; set; }
        public bool InLibrary { get; set; }    
        public Genre Genre { get; init; }
    }

    class Reader
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string FullName => $"{FirstName} {LastName}";
        private string HomeAdress { get; init; }
        private string WorkAdress { get; init; }
        private string PhoneNumber { get; set; }
        private int CountOfBooksTakenInLibrary { get; set; }     
    }

    class Staff
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string FullName => $"{FirstName} {LastName}";
        private string HomeAdress { get; init; }
        private string PhoneNumber { get; set; }
        private string Position { get; set; }
        private int DateStartWorking { get; init; }
        private int DateOfBirth { get; init; }

    }

    class Library 
    {
        public int DateOfBuilding { get; init; }
        public string Adress { get; set; }
        public int CountSitPlaces { get; init; }
        public string PhoneNumber { get; init; }
        public int QuantityOfBooks { get; set; }
        private int QuantityOfStaff { get; init; }


        
    }


class Program
    {
        static void Main()
        {
        }
    }
}
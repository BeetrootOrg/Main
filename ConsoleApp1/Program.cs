using System;

namespace ConsoleApp
{
    class IdCard
    {
        private string ID { get; set; }
        public string SubscriberName { get; set; }
        public List<Book> BorrowedBooks { get; set; }//aggregation with Book class
        class Subscriber//composition with IdCard class
        {
            public string Name { get; set; }
            public string Sex { get; set; }
            public string DateOfBirth { get; set; }
            public string PassportID { get; set; }
        }
    }
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearOfEdition { get; set; }
        public decimal AssessedValue { get; set; }
        public string Genre { get; set; }
        public string GivenTo { get; set; }
        public DateTime DateOfReturn { get; set; }

        public void FillInTheDetails (string name, string author, int yearofedition, decimal assessedvalue, string genre, string givento, DateTime dateofreturn)
        {
        Name=name;

        Author=author;

        YearOfEdition=yearofedition;

        AssessedValue=assessedvalue;

        Genre=genre;

        GivenTo = givento;

        DateOfReturn = dateofreturn;
        }
    }


    class Program
    {
        static void Main()
        {
        }
    }
}


using System;
using System.IO;

namespace ConsoleApp
{
    class Library
    {
        public string locationLib { get; set; }
        public string nameLib { get; set; }
        private string librarianId { get; set; }


    }
    class Books
    {
        private string bookId { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string status { get; set; }
    }
    class Librarian
    {
        private string librarianId { get; set; }
        public string librarianInfo { get; set; }
    }
    class User
    {
        private string userId { get; set; }
        private string userInfo { get; set; }
        public string penalties { get; set; }

    }
    class Shop
    {
        private string bookId { set; get; }
        private string userId { set; get; }
        public string PaymantSys { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomeworkOOP
{
    class Library
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; }
        public List<Contract> Contracts { get; set; }
        public List<Client> Clients { get; set; }
        public decimal Сashbox { get; set; }

        public void CreateContract(Book book, Client client) => throw new NotImplementedException(); 

        public void AddBook() => throw new NotImplementedException();

        public void AddClient() => throw new NotImplementedException();

        public Client FiendClient(int clientId) => throw new NotImplementedException();

        public Book FiendBook(int bookId) => throw new NotImplementedException();

        public Contract FiendContract(int contractId) => throw new NotImplementedException();

    }

}

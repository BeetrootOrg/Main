using System;
using System.Collections.Generic;

namespace EntityFrameworkApp.Models
{
    public partial class BookAuthor
    {
        public BookAuthor()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

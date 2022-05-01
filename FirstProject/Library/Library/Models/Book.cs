using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Book
    {
        public Book()
        {
            Histories = new HashSet<History>();
        }

        public int Id { get; set; }
        public string NameBook { get; set; }
        public int AuthorId { get; set; }
        public int CountsOfBook { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}

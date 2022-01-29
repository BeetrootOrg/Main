using System;
using System.Collections.Generic;

namespace EntityFrameworkApp.Models
{
    public partial class Book
    {
        public Book()
        {
            TakenHistories = new HashSet<TakenHistory>();
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; } = null!;

        public virtual BookAuthor Author { get; set; } = null!;
        public virtual ICollection<TakenHistory> TakenHistories { get; set; }
    }
}

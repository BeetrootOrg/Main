using System;
using System.Collections.Generic;

namespace EntityFramework28.Domain
{
    public partial class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}

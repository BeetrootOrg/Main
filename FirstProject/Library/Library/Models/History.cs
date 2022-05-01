using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public DateTime DateWhenTaken { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EntityFrameworkApp.Models
{
    public partial class TakenHistory
    {
        public int Id { get; set; }
        public int BookTaken { get; set; }
        public int TakenBy { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime? DateReturned { get; set; }

        public virtual Book BookTakenNavigation { get; set; } = null!;
        public virtual LibraryUser TakenByNavigation { get; set; } = null!;
    }
}

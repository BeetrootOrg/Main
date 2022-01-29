using System;
using System.Collections.Generic;

namespace EntityFrameworkApp.Models
{
    public partial class LibraryUser
    {
        public LibraryUser()
        {
            TakenHistories = new HashSet<TakenHistory>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateRegistered { get; set; }

        public virtual ICollection<TakenHistory> TakenHistories { get; set; }
    }
}

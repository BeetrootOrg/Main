using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Histories = new HashSet<History>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}

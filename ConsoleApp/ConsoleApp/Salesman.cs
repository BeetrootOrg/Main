using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public partial class Salesman
    {
        public Salesman()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

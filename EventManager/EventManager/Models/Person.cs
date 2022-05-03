using System;
using System.Collections.Generic;

namespace EventManager.Models
{
    public partial class Person
    {
        public Person()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}

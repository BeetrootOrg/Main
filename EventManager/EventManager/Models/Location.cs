using System;
using System.Collections.Generic;

namespace EventManager.Models
{
    public partial class Location
    {
        public Location()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string LocationAddress { get; set; }
        public int PersonsId { get; set; }

        public virtual Person Persons { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}

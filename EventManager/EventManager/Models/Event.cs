using System;
using System.Collections.Generic;

namespace EventManager.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}

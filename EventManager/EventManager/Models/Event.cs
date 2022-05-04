using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        [DisplayName("Your event name")]
        [Required]
        public string EventName { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCreator.Models
{
    public partial class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int? PeopleJoined { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

}

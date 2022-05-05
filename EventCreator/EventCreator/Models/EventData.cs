using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCreator.Models
{
    public partial class EventData
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EventName { get; set; } = null!;
        public string? EventDescription { get; set; }
        public int? PeopleJoined { get; set; }
    }

}

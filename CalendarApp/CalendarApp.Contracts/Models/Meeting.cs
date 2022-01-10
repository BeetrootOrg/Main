using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Contracts.Models
{
    public record Meeting
    {
        public string Name{ get; init; }
        public DateTime StartAt{ get; init; }
        public TimeSpan Duration { get; init; }
        public DateTime EndAt => StartAt.Add(Duration);
        public Room Room { get; init; }
    }
}

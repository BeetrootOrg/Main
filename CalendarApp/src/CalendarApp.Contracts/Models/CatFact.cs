using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Contracts.Models
{
    public class CatFact
    {
       public Status Status { get; set; }
       public int Id { get; set; }
       public string Type { get; set; }
       public bool Deleted { get; set; }
       public string User { get; set; }
       public string Text { get; set; }
       public DateTime CreatedAt { get; set; }
       public DateTime UpdatedAt { get; set; }
}
}

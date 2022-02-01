using System;
using System.Collections.Generic;

namespace EntityFramework28.Domain
{
    public partial class BookHistory
    {
        public int BookId { get; set; }
        public DateTime ReservationTime { get; set; }
        public int CustomerId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

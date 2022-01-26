using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public partial class Order
    {
        public int Id { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTime OrderDatetime { get; set; }
        public int CustomerId { get; set; }
        public int? SalesmanId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Salesman Salesman { get; set; }
    }
}

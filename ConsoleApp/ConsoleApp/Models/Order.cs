using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("Orders", Schema = "dbo")]
    public record Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTime PurchasedAt { get; set; }
        public int CustomerId { get; set; }
        public int? SalesmanId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("SalesmanId")]
        public Salesman Salesman { get; set; }
    }
}

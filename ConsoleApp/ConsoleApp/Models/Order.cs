using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("Orders", Schema = "dbo")]
    public class Order
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("PurchaseAmount")]
        public decimal PurchaseAmount { get; set; }

        [Column("OrderDatetime")]
        public DateTime OrderDateTime { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("SalesmanId")]
        public int SalesmanId { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp
{
    [Table("BookHistory", Schema = "dbo")]
    public class HistoryBook
    {
        [Key]
        public int BookId { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("BookId")]
        public Book ThisBook { get; set; }

        [ForeignKey("CustomerId")]
        public Customer TakenByCustomer { get; set; }
        public DateTime TakenTime { get; set; }
        public DateTime ReturnedTime { get; set; }
    }
}

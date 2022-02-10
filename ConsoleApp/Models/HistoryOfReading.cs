using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("HistoryOfReading", Schema = "dbo")]
    public class HistoryOfReading
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public DateTime DateOfBorrow { get; init; }

        public DateTime DateOfReturn { get; init; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [ForeignKey("CustromerId")]
        
        public Customer Customer { get; set; }

    }
}

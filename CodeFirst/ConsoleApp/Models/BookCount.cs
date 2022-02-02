using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("BookCounts", Schema = "dbo")]
    public record BookCount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public int? BookId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int? Quantity { get; set; }
        public BookCount()
        {
            Quantity = 1;
        }
    }
}

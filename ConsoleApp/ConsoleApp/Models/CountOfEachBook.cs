using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp
{
    [Table("CountOfEachBooks", Schema = "dbo")]
    public class CountOfEachBook
    {
        [Key]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book ThisBook { get; set; }
        public int CountOfBook { get; set; }
    }
}

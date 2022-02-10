using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Models
{
    [Table("Books", Schema = "dbo")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string BookName { get; set; }
        
        [Required]
        [MinLength(1)]

        public int AuthorId { get; set; }

        [Required]
        [MinLength(4)]

        public DateTime DateOfCreating { get; init; }

        [Required]
        [MaxLength(1000)]
        [MinLength(1)]
        public int QuanityInLibrary { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}

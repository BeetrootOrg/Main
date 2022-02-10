using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Models
{
    [Table("Authors", Schema ="dbo")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string LastName{ get; set; }

        [Required]
        [MinLength(1)]
        public DateTime DateOfBirth { get; set; }

    }
}

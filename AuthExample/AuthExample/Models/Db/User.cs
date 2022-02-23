using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthExample.Models.Db
{
    [Table("Users", Schema = "dbo")]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        [MaxLength(255)]
        public string Email { get; init; }

        [Required]
        [MaxLength(500)]
        public string Password { get; init; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models
{
    [Table("Customers", Schema = "dbo")]
    public record Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        [MinLength(1)]
        public string LastName { get; set; }
    }
}

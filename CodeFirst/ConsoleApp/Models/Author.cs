using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsoleApp.Models
{
    [Table("Authors", Schema = "dbo")]
    public record Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        [MinLength(1)]
        public string Name { get; set; }
    }
}

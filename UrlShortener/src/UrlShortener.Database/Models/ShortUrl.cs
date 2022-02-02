using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Database.Models
{
    [Table("Urls", Schema = "dbo")]
    [Index(nameof(Url), IsUnique = true)]
    [Index(nameof(Hash), IsUnique = true)]
    public class ShortUrl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; init; }

        [Column("Url")]
        [Required]
        [MaxLength(255)]
        public string Url { get; init; }

        [Column("Hash")]
        [Required]
        [MaxLength(50)]
        public string Hash { get; init; }

        public DateTime CreatedAt { get; init; }
    }
}

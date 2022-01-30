using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Database.Models
{
    [Table("Urls", Schema = "dbo")]
    [Index(nameof(Original), nameof(Short), IsUnique = true)]
    public class ShortUrl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("OriginalUrl")]
        [Required]
        public string Original { get; set; }

        [Column("ShortUrl")]
        [Required]
        public string Short { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

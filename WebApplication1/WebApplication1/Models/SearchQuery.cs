using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SearchQuery
    {
        [Required]
        public string? Query { set; get; }
    }
}

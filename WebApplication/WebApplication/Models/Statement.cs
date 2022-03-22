using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Statement
    {

        public int Id { get; init; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; init; }

        public User Plaintiff { get; set; }

        public User Defendant { get; set; }

        public Court Court { get; set; }

    }
}

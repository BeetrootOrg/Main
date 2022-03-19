using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FistName + " " + Patrimonic; ;
            }
            
        }

        [DisplayName("First Name")]
        public string FistName { get; set; }
        public string Patrimonic { get; set; }

        [DisplayName("Tax Number")]
        [Required]
        public int TaxNumber { get; init; }

        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }

    }


}

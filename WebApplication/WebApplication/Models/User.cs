using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class User
    {
        public int Id { get; set; }

        private DateTime _dateOfBirth;

        [DisplayName("Дата народження")]
        [DataType(DataType.Date)]

        public DateTime DateOfBirth
        {

            set=> _dateOfBirth = value;
            get => _dateOfBirth.Date;

        }


        [DisplayName("Прізвище")]

        public string LastName { get; set; }

        [DisplayName("Ім'я")]
        public string FistName { get; set; }

        [DisplayName("Патронім")]
        public string Patrimonic { get; set; }

        public string FullName => $"{LastName} {FistName} {Patrimonic}";

        [DisplayName("Податковий номер")]
        [Required]
        public ulong TaxNumber { get; init; }

 










        [DisplayName("Адреса")]
        public string Address { get; set; }

        [DisplayName("Електронна пошта")]

        public string Email { get; set; }

    }


}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class User
    {
        private DateTime _dateOfBirth;
        public int Id { get; set; }

        [DisplayName("Ім'я")]
        public string FistName { get; set; }

        [DisplayName("По батькові")]
        public string Patronymic { get; set; }

        [DisplayName("Прізвище")]
        public string LastName { get; set; }

        public string FullName => $"{LastName} {FistName} {Patronymic}";

        [DisplayName("Дата народження")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth
        {
            set => _dateOfBirth = value;
            get => _dateOfBirth.Date;
        }

        [DisplayName("Податковий номер")]
        [Required]
        public ulong TaxNumber { get; init; }

        [DisplayName("Адреса")]
        public string Address { get; set; }

        [DisplayName("Електронна пошта")]
        public string Email { get; set; }

    }


}

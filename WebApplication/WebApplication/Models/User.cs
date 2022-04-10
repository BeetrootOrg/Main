using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class User
    {
        private DateTime _dateOfBirth;

        public int Id { get; set; }

        [DisplayName("Прізвище")]
        public string LastName { get; set; }

        [DisplayName("Ім'я")]
        public string FirstName { get; set; }

        [DisplayName("По батькові")]
        public string Patronymic { get; set; }

        [DisplayName("Прізвище ім'я по батькові")]
        public string FullName => $"{LastName} {FirstName} {Patronymic}";

        [DisplayName("Дата народження")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value;
        }

        [DisplayName("Податковий номер")]
        [Required]
        public long TaxNumber { get; init; }

        [DisplayName("Адреса")]
        public string Address { get; set; }

        [DisplayName("Електронна пошта")]
        public string Email { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EntityFramework28.Domain
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}

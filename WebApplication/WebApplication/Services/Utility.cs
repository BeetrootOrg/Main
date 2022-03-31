using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class Utility
    {
        public static User GetUserById(IList<User> users, int id)
        {
            var user = users.First(x => x.Id == id);
            return user;
        }
        public static Court GetCourtById(IList<Court> courts, int id)
        {
            var court = courts.First(x => x.Id == id);
            return court;
        }

        public static readonly IList<User> _usersContext = new List<User>
        {
            new User
            {
                Id = 1,
                FistName="Петро",
                Patronymic="Петрович",
                LastName="Ковальский",
                TaxNumber=1234567890,
                DateOfBirth=DateTime.Now,
                Address="65012, Одеса, вул. Архітекторська, 18, кв. 12",
                Email="test@text.gmail.com"
            },
            new User
            {
                Id = 2,
                FistName="Іван",
                Patronymic="Іванович",
                LastName="Іванов",
                TaxNumber=1231237890,
                DateOfBirth=DateTime.Now,
                Address="65027",
                Email="test2@gmail.com"
            }
        };
    }
}

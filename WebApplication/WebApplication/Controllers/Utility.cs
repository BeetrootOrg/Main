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
    }
}

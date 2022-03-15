using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Models
{
    public class UserController : Controller
    {
        public User GetUserByID(IList<User> users, int id)
        {
            var user = users.First(x => x.Id == id);
            return user;
        }

        private static readonly IList<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FistName="Петро",
                Patrimonic="Петрович",
                LastName="Ковальский",
                TaxNumber=1234567890,
                DateOfBirth=DateTime.Now,
                Address="65012, Одеса, вул. Архітекторська, 18, кв. 12",
                Email="test@text.gmail.com"
            }
        };
        // GET: UserController
        public ActionResult Index()
        {
            return View(_users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {

            return View(GetUserByID(_users, id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] User user)
        {
            try
            {
                user.Id=_users.Count+1;
                _users.Add(user);
  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            //var user = _users.First(user => user.Id == id);
            return View(GetUserByID(_users, id));

        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] User user)
        {
            try
            {
                _users.RemoveAt(id-1);
                user.Id = id;
                _users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            // var user = _users.First(user => user.Id == id);
            return View(GetUserByID(_users, id));
            //return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] User user)
        {
            try
            {
                _users.RemoveAt(id - 1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

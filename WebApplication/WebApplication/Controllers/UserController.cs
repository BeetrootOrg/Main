using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using static WebApplication.Services.WorkingWithUser;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        IUserRepository userRepoContext;
        public UserController(IUserRepository r) => userRepoContext = r;
        public ActionResult Index()
        {
            return View(userRepoContext.GetUsersList());
        }
        public ActionResult Details(int id)
        {
            return View(userRepoContext.GetUser(id));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                userRepoContext.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View(userRepoContext.GetUser(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                userRepoContext.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(userRepoContext.GetUser(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                userRepoContext.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

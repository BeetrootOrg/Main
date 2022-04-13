using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepoContext;
        public UserController(IUserRepository userRepoContext) => _userRepoContext = userRepoContext;
        public ActionResult Index()
        {
            return View(_userRepoContext.GetUsersListAsync().Result);
        }
        public ActionResult Details(int id)
        {
            return View(_userRepoContext.GetUserAsync(id).Result);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            _userRepoContext.CreateUserAsync(user);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            return View(_userRepoContext.GetUserAsync(id).Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            _userRepoContext.UpdateUserAsync(user);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            return View(_userRepoContext.GetUserAsync(id).Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                _userRepoContext.DeleteUserAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

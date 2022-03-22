using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {



        // GET: UserController
        public ActionResult Index()
        {
            return View(Utility._usersContext);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {

            return View(Utility.GetUserById(Utility._usersContext, id));
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
                user.Id= Utility._usersContext.Count+1;
                Utility._usersContext.Add(user);
  
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
            return View(Utility.GetUserById(Utility._usersContext, id));

        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] User user)
        {
            try
            {
                Utility._usersContext.RemoveAt(id-1);
                user.Id = id;
                Utility._usersContext.Add(user);
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
            return View(Utility.GetUserById(Utility._usersContext, id));
            //return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] User user)
        {
            try
            {
                Utility._usersContext.RemoveAt(id - 1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

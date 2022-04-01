using Microsoft.AspNetCore.Mvc;
using System.Linq;

using WebApplication.Models;
using static WebApplication.Services.WorkingWithUserRepository;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
       private readonly IUserRepository userRepoContext;
       public UserController(IUserRepository r)
       {
           userRepoContext = r;
       }

        // GET: UserController
        public ActionResult Index()
        {
            //return View(Utility._usersContext);
            return View(userRepoContext.GetUsers());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {

            //return View(Utility.GetUserById(Utility._usersContext, id));
            return View(userRepoContext.Get(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                userRepoContext.Create(user);
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
 //           var user = Utility._usersContext.First(user => user.Id == id);
            return View(userRepoContext.Get(id));
            //return View(user);

        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                //Utility._usersContext.RemoveAt(id - 1);
  //              user.Id = id;
                //Utility._usersContext.Add(user);
                userRepoContext.Update(user);
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
            
            //var user = Utility._usersContext.First(user => user.Id == id);
            //return View(Utility.GetUserById(Utility._usersContext, id));
            return View(userRepoContext.Get(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,User user)
        {
            try
            {
                //Utility._usersContext.RemoveAt(id - 1);
                userRepoContext.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

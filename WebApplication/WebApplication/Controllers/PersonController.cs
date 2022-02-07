using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PersonController : Controller
    {
        private static readonly IList<Person> _persons = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "D",
                LastName = "M"
            }
        };

        public ActionResult Index()
        {
            return View(_persons);
        }

        public ActionResult Details(int id)
        {
            var person = _persons.First(person => person.Id == id);
            return View(person);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Person person)
        {
            try
            {
                _persons.Add(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var person = _persons.First(person => person.Id == id);
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int id, [FromForm] Person person)
        {
            try
            {
                var oldPerson = _persons.First(person => person.Id == id);
                _persons.Remove(oldPerson);
                _persons.Add(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var person = _persons.First(person => person.Id == id);
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection form)
        {
            try
            {
                var oldPerson = _persons.First(person => person.Id == id);
                _persons.Remove(oldPerson);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

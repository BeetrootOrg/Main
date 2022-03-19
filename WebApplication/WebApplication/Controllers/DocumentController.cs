using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DocumentController : Controller
    {

        private static readonly IList<Document> _documents  = new List<Document>(); 
        private static readonly IList<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FistName="Петро",
                Patrimonic="Петрович",
                LastName="3Ковальский",
                TaxNumber=1234567890,
                DateOfBirth=DateTime.Now,
                Address="65012, Одеса, вул. Архітекторська, 18, кв. 12",
                Email="test@text.gmail.com"
            },
            new User
            {
                Id = 2,
                FistName="Іван",
                Patrimonic="Іванович",
                LastName="2Ломаченко",
                TaxNumber=1231237890,
                DateOfBirth=DateTime.Now,
                Address="65027",
                Email="test2@gmail.com"
            }
        };
        private static readonly IList<Court> _courts = new List<Court>
        {
            new Court
            {
                Id=3,
                Name="Приморський районний суд міста Одеси",
                Adress="65029, м. Одеса, вул. Балківська, 33",
            },
            new Court
            {
                Id=1,
                Name="Київський районний суд міста Одеси",
                Adress="65080, м. Одеса, вул. Варненська, 3-б",
            },
            new Court
            {
                Id=4,
                Name="Суворовський районний суд міста Одеси",
                Adress="65003, м. Одеса, вул. Чорноморського козацтва, 68",
            },
            new Court
            {
                Id=2,
                Name="Малиновський районний суд міста Одеси",
                Adress="65033, м. Одеса, вул. В. Стуса, 1а",
            },

        };


        // GET: DocumentController
        public ActionResult Index()
        {
            IList<SelectListItem> users = new List<SelectListItem>();

            foreach (var item in _users)
            {
                users.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FullName });
 
            }

 

            IList<SelectListItem> courts = new List<SelectListItem>();

 
            foreach (var item in _courts)
            {
                courts.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name});
            }
 
            ViewBag.users = users;
            
            ViewBag.courts = courts;

            return View(_documents);
        }

        // GET: DocumentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentController/Create
        public ActionResult Create()
        {
            IList<SelectListItem> users = new List<SelectListItem>();

            foreach (var item in _users)
            {
                users.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.FullName });
            }



            IList<SelectListItem> courts = new List<SelectListItem>();


            foreach (var item in _courts)
            {
                courts.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            ViewBag.users = users;

            ViewBag.courts = courts;
            return View();
        }

        // POST: DocumentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int plaintiff, int defendant, int court )
        {
            try
            {
                //_documents.Add(x=> x.User1.Id = firstUser)
                Document newDocument=CreateDocumentTemplate(_users,plaintiff,defendant,_courts,court);
                _documents.Add(newDocument);
                ChangeTemplateForDownloading(newDocument);
                
                return RedirectToAction(nameof(Index));
                //return View(_documents);
            }
            catch
            {
                return View();
            }
        }

        private static Document ChangeTemplateForDownloading(Document newDocument)
        { 

        }

        private static Document CreateDocumentTemplate(IList<User> users, int plaintiff, int defendant, IList<Court> courts, int court)
        {
            Document document = new()
            {
                Title = "First",
                Plaintiff = Utility.GetUserById(users,plaintiff),
                Defendant=Utility.GetUserById(users,defendant),
                Court=Utility.GetCourtById(courts,court),
                DateOfCreation=DateTime.Today,
            };
            return document;


        }

        // GET: DocumentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocumentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

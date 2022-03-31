using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using WebApplication.Models;
using Spire.Doc;
using IOFile= System.IO.File;
using System.Collections.Generic;
using System;
using System.IO;

namespace WebApplication.Controllers
{
    public class StatementController : Controller
    {



        
        private static readonly IList<Statement> _statements  = new List<Statement>(); 

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


        // GET: StatementController
        public ActionResult Index()
        {
            IList<SelectListItem> users = new List<SelectListItem>();

            foreach (var item in Utility._usersContext)
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

            return View(_statements);
        }

        // GET: StatementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StatementController/Create
        public ActionResult Create()
        {
            IList<SelectListItem> users = new List<SelectListItem>();

            foreach (var item in Utility._usersContext)
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

        // POST: StatementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int plaintiff, int defendant, int court )
        {
            try
            {
                
                Statement newStatement = CreateObjectWithDataForTemplate(Utility._usersContext, plaintiff, defendant, _courts, court) ;
                _statements.Add(newStatement);
                string filename = CreateStatementForDownloading(newStatement);

                //GetFile(filename);

                              
                return LocalRedirect($"/api/files/{filename}");
                //return View(newStatement);
            }
            catch
            {
                return View(Utility._usersContext);
            }
        }




        private static string CreateStatementForDownloading(Statement newDocument)
        {
              
            User Plantiff = newDocument.Plaintiff;
            User Defendant = newDocument.Defendant;

            object o = newDocument.Plaintiff;
            Type type = o.GetType();
            
            Document doc = new Document();
            doc.LoadFromFile("Files/Divorce.docx");
            string replaceText;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                replaceText = (prop.PropertyType.Name != "DateTime") 
                    ? prop.GetValue(o)?.ToString() 
                    : Plantiff.DateOfBirth.ToString("d");

                doc.Replace($"[Plantiff.{prop.Name}]", replaceText, false, true);
                Console.WriteLine($"Plantiff.{prop.Name} {prop.PropertyType.Name} has value {prop.GetValue(o)}");
            };
            o = newDocument.Defendant;
            type = o.GetType();
           
            foreach (PropertyInfo prop in type.GetProperties())
            {
                replaceText = (prop.PropertyType.Name != "DateTime")
                    ? prop.GetValue(o)?.ToString()
                    : Defendant.DateOfBirth.ToString("d");

                doc.Replace($"[Defendant.{prop.Name}]", replaceText, false, true);
                Console.WriteLine($"Defendant.{prop.Name} {prop.PropertyType.Name} has value {prop.GetValue(o)}");
            }
            
            Guid guid = Guid.NewGuid();

            string fileName =$"{guid}.docx";
            string directory = Path.GetTempPath();
            doc.SaveToFile($"{directory}{fileName}", FileFormat.Docx2013);

            return fileName;
            
        }
        
        private static Statement CreateObjectWithDataForTemplate(IList<User> users, int plaintiff, int defendant, IList<Court> courts, int court)
        {

        Statement statement = new()
            {
                Id = _statements.Count+1,
                Title = "First",
                Plaintiff = Utility.GetUserById(users,plaintiff),
                Defendant=Utility.GetUserById(users,defendant),
                Court=Utility.GetCourtById(courts,court),
                DateOfCreation=DateTime.Today,
            };
            return statement;


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

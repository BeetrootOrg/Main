using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;
using System.Collections.Generic;
using static WebApplication.Services.WorkingWithUser;
using static WebApplication.Services.WorkingWithCourt;
using static WebApplication.Services.WorkingWithStatement;

namespace WebApplication.Controllers
{
    public class StatementController : Controller
    {
        IUserRepository userRepoContext;
        ICourtRepository courtRepoContext;
        INewStatement statementRepoContext;
        IList<User> users;
        IList<Court> courts;
        IList<StatementKind> statementTypes;
        public StatementController(IUserRepository a, ICourtRepository b, INewStatement c)
        {
            userRepoContext = a;
            courtRepoContext = b;
            statementRepoContext = c;
        }

        // GET: StatementController/Create
        public ActionResult Create()
        {
            users = userRepoContext.GetUsersList();
            courts = courtRepoContext.GetCourtsList();
            statementTypes = statementRepoContext.GetAllStatementKinds();
            IndexViewModel ivm = new() { Users = users, Courts = courts, StatementKinds = statementTypes };
            return View(ivm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int plaintiff, int defendant, int kind, int court)
        {
            try
            {
                User plaintiffInfo = userRepoContext.GetUser(plaintiff);
                User defendantInfo = userRepoContext.GetUser(defendant);
                StatementKind statementKindInfo = statementRepoContext.GetStatemenKind(kind);
                Court courtInfo = courtRepoContext.GetCourt(court);
                Statement newStatement = statementRepoContext.CreateStatement(plaintiffInfo, defendantInfo, statementKindInfo, courtInfo);
                string filename = statementRepoContext.EditTemplateForDownloading(newStatement);
                return LocalRedirect($"/api/files/{filename}");
            }
            catch
            {
                users = userRepoContext.GetUsersList();
                courts = courtRepoContext.GetCourtsList();
                statementTypes = statementRepoContext.GetAllStatementKinds();
                IndexViewModel ivm = new IndexViewModel { Users = users, Courts = courts, StatementKinds = statementTypes };
                return View(ivm);
            }
        }
    }
}




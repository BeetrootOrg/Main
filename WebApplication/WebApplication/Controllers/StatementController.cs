using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;
using System.Collections.Generic;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class StatementController : Controller
    {
        private readonly IUserRepository _userRepoContext;
        private readonly ICourtRepository _courtRepoContext;
        private readonly INewStatement _statementRepoContext;
        public StatementController(IUserRepository userRepoContext, ICourtRepository courtRepoContext, INewStatement statementRepoContext)
        {
            _userRepoContext = userRepoContext;
            _courtRepoContext = courtRepoContext;
            _statementRepoContext = statementRepoContext;
        }
        public ActionResult Create()
        {
            List<User> users = _userRepoContext.GetUsersList();
            List<Court> courts = _courtRepoContext.GetCourtsList();
            List<StatementKind> statementTypes = _statementRepoContext.GetAllStatementKinds();
            IndexViewModel ivm = new() { Users = users, Courts = courts, StatementKinds = statementTypes };
            return View(ivm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int plaintiff, int defendant, int kind, int court)
        {
            try
            {
                User plaintiffInfo = _userRepoContext.GetUser(plaintiff);
                User defendantInfo = _userRepoContext.GetUser(defendant);
                StatementKind statementKindInfo = _statementRepoContext.GetStatemenKind(kind);
                Court courtInfo = _courtRepoContext.GetCourt(court);
                Statement newStatement = _statementRepoContext.CreateStatement(plaintiffInfo, defendantInfo, statementKindInfo, courtInfo);
                string filename = _statementRepoContext.EditTemplateForDownloading(newStatement);
                return LocalRedirect($"/api/files/{filename}");
            }
            catch
            {
                List<User> users = _userRepoContext.GetUsersList();
                List<Court> courts = _courtRepoContext.GetCourtsList();
                List<StatementKind> statementTypes = _statementRepoContext.GetAllStatementKinds();
                IndexViewModel ivm = new() { Users = users, Courts = courts, StatementKinds = statementTypes };
                return View(ivm);
            }
        }
    }
}




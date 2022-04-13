using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.ViewModels;
using System.Collections.Generic;
using WebApplication.Services;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;

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
        public async Task<ActionResult> CreateAsync()
        {
            try
            {
                var userRepoTask = _userRepoContext.GetUsersListAsync();
                var courtRepoTask = _courtRepoContext.GetCourtsListAsync();
                var statementKindTask = _statementRepoContext.GetAllStatementKindsAsync();
                await Task.WhenAll(userRepoTask, courtRepoTask, statementKindTask);
                List<User> users = userRepoTask.Result;
                List<Court> courts = courtRepoTask.Result;
                List<StatementKind> statementTypes = statementKindTask.Result;

                IndexViewModel ivm = new() { Users = users, Courts = courts, StatementKinds = statementTypes };
                return View(ivm);
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    Trouble = $"{ex.Message}. Please try refresh page." +
                    " If you see this warning again - contact site administrator by email vladimir.danilin@gmail.com"
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int plaintiff, int defendant, int kind, int court)
        {
            try
            {
                var plaintiffTask = _userRepoContext.GetUserAsync(plaintiff);
                var defendantTask = _userRepoContext.GetUserAsync(defendant);
                var statementKindTask = _statementRepoContext.GetStatemenKindAsync(kind);
                var courtInfoTask = _courtRepoContext.GetCourtAsync(court);
                User plaintiffInfo = plaintiffTask.Result;
                User defendantInfo = defendantTask.Result;
                StatementKind statementKindInfo = statementKindTask.Result;
                Court courtInfo = courtInfoTask.Result;
                await Task.WhenAll(plaintiffTask, defendantTask, statementKindTask, courtInfoTask);
                Statement newStatement = _statementRepoContext.CreateStatement(plaintiffInfo, defendantInfo, statementKindInfo, courtInfo);
                string filename = _statementRepoContext.EditTemplateForDownloading(newStatement);
                return LocalRedirect($"/api/files/{filename}");
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    Trouble = $"{ex.Message}. Please try refresh page." +
                    " If you see this warning again - contact site administrator by email vladimir.danilin@gmail.com"
                });
            }
        }
    }
}




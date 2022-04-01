using WebApplication.Models;
using static WebApplication.Services.WorkingWithStatements;
using static WebApplication.Controllers.UserController;

namespace WebApplication.Services
{
    public class WorkingWithStatements
    {
        public interface INewStatement
        {
            Statement CreateStatement(int plaintiff, int defendant, int typeOfDocument, int court);
        }
    };

    public class NewStatement : INewStatement
    {
        private static int _statementsCounter;
        public Statement CreateStatement(int plaintiff, int defendant, int typeOfDocument, int court)
        {
            Statement statement = new()
            {
                Id = ++_statementsCounter,
                Title = "Default",
                Plaintiff = UserRepoContext.Get,
                Defendant = Utility.GetUserById(users, defendant),
                Court = Utility.GetCourtById(courts, court),
                DateOfCreation = DateTime.Today,
            };
            return statement;
        }
    }
}

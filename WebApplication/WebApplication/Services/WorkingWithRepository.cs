using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using WebApplication.Models;
using Spire.Doc;
using System.Reflection;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace WebApplication.Services
{
    public interface ICourtRepository
    {
        Task<Court> GetCourtAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Court>> GetCourtsListAsync(CancellationToken cancellationToken = default);

    }
    public class CourtRepository : ICourtRepository
    {
        private readonly string _connectionString;
        public CourtRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Court> GetCourtAsync(int id, CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Query<Court>("SELECT * FROM Courts WHERE Id = @id", new { id }).FirstOrDefault();
            return await Task.FromResult(result);
        }
        public async Task<List<Court>> GetCourtsListAsync(CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Query<Court>("SELECT * FROM Courts").ToList();
            return await Task.FromResult(result);
        }

    }
    public interface INewStatement
    {
        Statement CreateStatement(User plaintiff, User defendant, StatementKind statementType, Court court);
        Task<StatementKind> GetStatemenKindAsync(int id, CancellationToken cancellationToken = default);
        Task<List<StatementKind>> GetAllStatementKindsAsync(CancellationToken cancellationToken = default);
        string EditTemplateForDownloading(Statement statement);
    }
    public class NewStatement : INewStatement
    {
        private static int _statementsCounter;
        private string _connectionString;
        public NewStatement(string connectionString="")
        {
            _connectionString = connectionString;
        }
        public Statement CreateStatement(User plaintiff, User defendant, StatementKind statementKind, Court court)
        {
            Statement statement = new()
            {
                Id = ++_statementsCounter,
                Title = "Default",
                Plaintiff = plaintiff,
                Defendant = defendant,
                StatementKind = statementKind,
                Court = court,
                DateOfCreation = DateTime.Now,
            };
            var result = statement;
            return result;
        }
        public async Task<StatementKind> GetStatemenKindAsync(int id, CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Query<StatementKind>("SELECT * FROM StatementKinds WHERE Id = @id", new { id }).FirstOrDefault();
            return await Task.FromResult(result);
        }
        public async Task<List<StatementKind>> GetAllStatementKindsAsync(CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Query<StatementKind>("SELECT * FROM StatementKinds").ToList();
            return await Task.FromResult(result);
        }
        public string EditTemplateForDownloading(Statement statement)
        {
            User Plantiff = statement.Plaintiff;
            User Defendant = statement.Defendant;
            StatementKind statementKind = statement.StatementKind;
            using Document doc = new();
            doc.LoadFromFile($"Files/{statementKind.Type}.docx");
            ReplaceTextInDocument(doc, "statement", statement);
            ReplaceTextInDocument(doc, "Plantiff", Plantiff);
            ReplaceTextInDocument(doc, "Defendant", Defendant);
            Guid guid = Guid.NewGuid();
            string fileName = $"{guid}.docx";
            string directory = Path.GetTempPath();
            doc.SaveToFile($"{directory}{fileName}", FileFormat.Docx2013);
            return fileName;
        }
        public void ReplaceTextInDocument(Document doc, string sourсeName, object obj)
        {
            Type type = obj.GetType();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                var value = prop.GetValue(obj);
                var replaceText = value is DateTime dt
                    ? dt.ToString("d")
                    : value.ToString();
                doc.Replace($"[{sourсeName}.{prop.Name}]", replaceText, false, true);
            }
        }
    }
    public interface IUserRepository
    {
        Task CreateUserAsync(User user, CancellationToken cancellationToken = default);
        Task DeleteUserAsync(int id, CancellationToken cancellationToken = default);
        Task<User> GetUserAsync(int id, CancellationToken cancellationToken = default);
        Task<List<User>> GetUsersListAsync(CancellationToken cancellationToken = default);
        Task UpdateUserAsync(User user, CancellationToken cancellationToken = default);
    }
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString) => _connectionString = connectionString;
        public async Task<List<User>> GetUsersListAsync(CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Query<User>("SELECT * FROM Users").ToList();
            return await Task.FromResult(result);
        }
        public async Task<User> GetUserAsync(int id, CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            return await Task.FromResult(result);
        }
        public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "INSERT INTO Users (FirstName,Patronymic,LastName,DateOfBirth,TaxNumber,Address,Email) " +
               "VALUES(@FirstName, @Patronymic,@LastName,@DateOfBirth,@TaxNumber,@Address,@Email)";
            db.Execute(sqlQuery, user);
            await Task.CompletedTask;
        }
        public async Task UpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "UPDATE Users SET FirstName = @FirstName, Patronymic = @Patronymic," +
                " LastName=@LastName, DateOfBirth=@DateOfBirth, TaxNumber=@TaxNumber, Address=@Address, Email=@Email" +
                " WHERE Id = @Id";
            db.Execute(sqlQuery, user);
            await Task.CompletedTask;
        }
        public async Task DeleteUserAsync(int id, CancellationToken cancellationToken = default)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "DELETE FROM Users WHERE Id = @id";
            db.Execute(sqlQuery, new { id });
            await Task.CompletedTask;
        }
    }

}

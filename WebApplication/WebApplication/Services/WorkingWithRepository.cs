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

namespace WebApplication.Services
{
    public interface ICourtRepository
    {
        Court GetCourt(int id);
        List<Court> GetCourtsList();
    }
    public class CourtRepository : ICourtRepository
    {
        private readonly string _connectionString;
        public CourtRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Court> GetCourtsList()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<Court>("SELECT * FROM Courts").ToList();
        }
        public Court GetCourt(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<Court>("SELECT * FROM Courts WHERE Id = @id", new { id }).FirstOrDefault();
        }
    }
    public interface INewStatement
    {
        Statement CreateStatement(User plaintiff, User defendant, StatementKind statementType, Court court);
        StatementKind GetStatemenKind(int id);
        List<StatementKind> GetAllStatementKinds();
        string EditTemplateForDownloading(Statement statement);
    }

    public class NewStatement : INewStatement
    {
        private static int _statementsCounter;
        private string _connectionString;
        public NewStatement(string connectionString)
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
            return statement;
        }
        public StatementKind GetStatemenKind(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<StatementKind>("SELECT * FROM StatementKinds WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }
        public List<StatementKind> GetAllStatementKinds()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<StatementKind>("SELECT * FROM StatementKinds").ToList();
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
        public void ReplaceTextInDocument(Document doc, string sourseName, object o)
        {
            Type type = o.GetType();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                var value = prop.GetValue(o);
                var replaceText = value is DateTime dt
                    ? dt.ToString("d")
                    : value.ToString();
                doc.Replace($"[{sourseName}.{prop.Name}]", replaceText, false, true);
            }
        }
    }
    public interface IUserRepository
    {
        void CreateUser(User user);
        void DeleteUser(int id);
        User GetUser(int id);
        List<User> GetUsersList();
        void UpdateUser(User user);
    }
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString) => _connectionString = connectionString;
        public List<User> GetUsersList()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<User>("SELECT * FROM Users").ToList();
        }
        public User GetUser(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
        }
        public void CreateUser(User user)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "INSERT INTO Users (FirstName,Patronymic,LastName,DateOfBirth,TaxNumber,Address,Email) " +
               "VALUES(@FirstName, @Patronymic,@LastName,@DateOfBirth,@TaxNumber,@Address,@Email)";
            db.Execute(sqlQuery, user);
        }
        public void UpdateUser(User user)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "UPDATE Users SET FirstName = @FirstName, Patronymic = @Patronymic," +
                " LastName=@LastName, DateOfBirth=@DateOfBirth, TaxNumber=@TaxNumber, Address=@Address, Email=@Email" +
                " WHERE Id = @Id";
            db.Execute(sqlQuery, user);
        }
        public void DeleteUser(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "DELETE FROM Users WHERE Id = @id";
            db.Execute(sqlQuery, new { id });
        }
    }

}

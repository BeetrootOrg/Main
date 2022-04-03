using WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Spire.Doc;
using System.Reflection;
using System.IO;

namespace WebApplication.Services
{
    public class WorkingWithStatement
    {
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
            private string connectionString;
            public NewStatement(string conString)
            {
                connectionString = conString;
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
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<StatementKind>("SELECT * FROM StatementKinds WHERE Id = @id", new { id }).FirstOrDefault();
                }
            }
            public List<StatementKind> GetAllStatementKinds()
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<StatementKind>("SELECT * FROM StatementKinds").ToList();
                }
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
            public void ReplaceTextInDocument(Document doc, String sourseName, object o)
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
    }
}

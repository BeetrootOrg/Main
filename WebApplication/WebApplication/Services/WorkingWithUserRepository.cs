using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class WorkingWithUserRepository
    {
        public interface IUserRepository
        {
            void Create(User user);
            void Delete(int id);
            User Get(int id);
            List<User> GetUsers();
            void Update(User user);
        }
        public class UserRepository : IUserRepository
        {
            string connectionString;
            public UserRepository(string conn)
            {
                connectionString = conn;
            }
            public List<User> GetUsers()
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<User>("SELECT * FROM Users").ToList();
                }
            }

            public User Get(int id)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
                }
            }

            public void Create(User user)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var sqlQuery = "INSERT INTO Users (FirstName,Patronymic,LastName,DateOfBirth,TaxNumber,Address,Email) " +
                       "VALUES(@FirstName, @Patronymic,@LastName,@DateOfBirth,@TaxNumber,@Address,@Email)";
                    db.Execute(sqlQuery,user);
                }
            }

            public void Update(User user)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var sqlQuery = "UPDATE Users SET FirstName = @FirstName, Patronymic = @Patronymic," +
                        " LastName=@LastName, DateOfBirth=@DateOfBirth, TaxNumber=@TaxNumber, Address=@Address, Email=@Email" +
                        " WHERE Id = @Id";
                    db.Execute(sqlQuery, user);
                }
            }

            public void Delete(int id)
            {
                using IDbConnection db = new SqlConnection(connectionString);
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}

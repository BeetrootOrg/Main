using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class WorkingWithUser
    {
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
            string connectionString;
            public UserRepository(string conn)
            {
                connectionString = conn;
            }
            public List<User> GetUsersList()
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<User>("SELECT * FROM Users").ToList();
                }
            }
            public User GetUser(int id)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
                }
            }
            public void CreateUser(User user)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var sqlQuery = "INSERT INTO Users (FirstName,Patronymic,LastName,DateOfBirth,TaxNumber,Address,Email) " +
                       "VALUES(@FirstName, @Patronymic,@LastName,@DateOfBirth,@TaxNumber,@Address,@Email)";
                    db.Execute(sqlQuery, user);
                }
            }
            public void UpdateUser(User user)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    var sqlQuery = "UPDATE Users SET FirstName = @FirstName, Patronymic = @Patronymic," +
                        " LastName=@LastName, DateOfBirth=@DateOfBirth, TaxNumber=@TaxNumber, Address=@Address, Email=@Email" +
                        " WHERE Id = @Id";
                    db.Execute(sqlQuery, user);
                }
            }
            public void DeleteUser(int id)
            {
                using IDbConnection db = new SqlConnection(connectionString);
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}

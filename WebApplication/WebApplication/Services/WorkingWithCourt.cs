using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class WorkingWithCourt
    {
        public interface ICourtRepository
        {
            Court GetCourt(int id);
            List<Court> GetCourtsList();
        }
        public class CourtRepository : ICourtRepository
        {
            string connectionString;
            public CourtRepository(string conn)
            {
                connectionString = conn;
            }
            public List<Court> GetCourtsList()
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<Court>("SELECT * FROM Courts").ToList();
                }
            }
            public Court GetCourt(int id)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    return db.Query<Court>("SELECT * FROM Courts WHERE Id = @id", new { id }).FirstOrDefault();
                }
            }
        }
    }
}

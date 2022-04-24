using Microsoft.AspNetCore.Mvc;
using WebApplication.Database;

namespace WebApplication.Services.Interfaces
{
    public interface IShowPdf
    {
        FileStreamResult CreatePdf(long id, OrderDbContext _context);
    }
}

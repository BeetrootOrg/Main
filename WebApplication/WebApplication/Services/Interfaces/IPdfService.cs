using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Services.Interfaces
{
    public interface IPdfService
    {
        FileStreamResult CreatePdf(long id);
    }
}

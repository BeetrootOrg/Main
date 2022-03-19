using Microsoft.AspNetCore.Mvc;
using IOFile = System.IO.File;

namespace WebApplication.Controllers
{
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private static readonly string Directory = (Path.GetFullPath("files"));

        [HttpGet("{filename}")]
        public async Task<IActionResult>  GetFile([FromRoute] string filename)
        {
            string fullPath = Path.Combine(Directory, filename);
            
            if (!IOFile.Exists(fullPath))
            {
                return NotFound(new
                {
                    Filename = filename,
                    Reason = "Not exists"
                });
            }

            var readStream = IOFile.OpenRead(fullPath);

            Response.Headers.ContentDisposition = $"attachment; filename=\"{filename}\"";
            return File(readStream, "application/octet-stream");
        }
    }
}

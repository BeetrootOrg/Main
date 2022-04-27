using AutoMapper;
using DAL.Entites.Base;
using DLL.Context;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Base;

namespace MagicShop.Controllers
{
    [Route("file")]
    public class FileUploadController : Controller
    {
        ArmoryDbContext _dbContext;
        IWebHostEnvironment _appEnvironment;
        IMapper _autoMapper;

        public FileUploadController(IWebHostEnvironment appEnvironment, ArmoryDbContext dbContext, IMapper autoMapper)
        {
            _dbContext = dbContext;
            _appEnvironment = appEnvironment;
            _autoMapper = autoMapper;
        }
        [HttpGet("getFile")]
        public IActionResult Index()
        {
            var files = _dbContext.Files.ToList();
            var models = _autoMapper.Map<List<BaseFileModel>>(files);
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                BaseFile file = new BaseFile { Name = uploadedFile.FileName, Path = path };
                _dbContext.Files.Add(file);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}

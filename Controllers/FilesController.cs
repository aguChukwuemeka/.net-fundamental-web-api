using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("/api/files")]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider) {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
             ?? throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public IActionResult GetFile(string fileId)
        {
            var pathToFile = "Ultimate-ASP.NET.pdf";

            if (!System.IO.File.Exists(pathToFile)){
                return NotFound();
            }

            if(!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType)) {
               contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
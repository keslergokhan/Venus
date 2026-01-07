using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Exceptions.Systems;
using Venus.Core.Application.Results.Extensions;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.Services.Interfaces;
using Venus.Core.Application.Services.Models;
using Venus.Presentation.Web.Cms.Server.Models.FileManagers;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly IFileManagerService _fileManager;

        public FileManagerController(IFileManagerService fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpPost]
        public async Task<IActionResult> GetFolders([FromBody] GetFoldersReq req)
        {
            IResultDataControl<GetFoldersOnPathResponse> result = await _fileManager.GetFoldersOnPathAsync(req.Path);
            
            return result.ToActionResult(this);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFilter([FromBody] RemoveFilterReq req)
        {
            var result = await _fileManager.RemoveFileAsync(req.Path);
            return result.ToActionResult(this);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileReq req) 
        {
            IResultControl result = await _fileManager.UploadFileAsync(Path.Combine(!string.IsNullOrEmpty(req.Path) ? req.Path : "/", req.File.FileName), req.File.OpenReadStream());
            return result.ToActionResult(this); 
        }
    }
}

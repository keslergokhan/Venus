using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Services.Interfaces;
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
            return Ok(await _fileManager.GetFoldersOnPathAsync(req.Path));
        }
    }
}

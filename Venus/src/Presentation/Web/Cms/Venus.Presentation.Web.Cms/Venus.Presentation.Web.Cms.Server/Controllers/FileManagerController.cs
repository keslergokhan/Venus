using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Exceptions.Systems;
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
        public async Task<IResultDataControl<GetFoldersOnPathResponse>> GetFolders([FromBody] GetFoldersReq req)
        {
            return await _fileManager.GetFoldersOnPathAsync(req.Path);
        }

        [HttpPost]
        public async Task<IResultControl> RemoveFilter([FromBody] RemoveFilterReq req)
        {
            return await _fileManager.RemoveFileAsync(req.Path);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Cms.FileManagers;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.Services.Models;

namespace Venus.Core.Application.Services.Interfaces
{
    public interface IFileManagerService
    {
        public string GetBaseFolder { get; }
        public Task<IResultDataControl<GetFoldersOnPathResponse>> GetFoldersOnPathAsync(string path);
        public Task<IResultControl> RemoveFileAsync(string fullPath);
    }
}

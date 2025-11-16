using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Cms.FileManagers;
using Venus.Core.Application.Results;
using Venus.Core.Application.Results.Interfaces;
using Venus.Core.Application.Services.Interfaces;
using Venus.Core.Application.Services.Models;

namespace Venus.Core.Application.Services
{
    public class FileManagerService : IFileManagerService
    {
        private readonly IWebHostEnvironment _env;

        public FileManagerService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string BaseFolderName => "filemanager";
        public string GetBaseFolder { 
            get {
                string wwwrootPath = _env.WebRootPath;
                return $"{wwwrootPath}/{BaseFolderName}";
            } 
        }


        public async Task<IResultDataControl<GetFoldersOnPathResponse>> GetFoldersOnPathAsync(string path)
        {
            IResultDataControl<GetFoldersOnPathResponse> result = new ResultDataControl<GetFoldersOnPathResponse>();
            GetFoldersOnPathResponse data = new GetFoldersOnPathResponse();
            try
            {
                if (path=="/")
                {
                    path = "";
                }
                string fullPath = this.GetBaseFolder.Replace("/","\\") + path.Replace("/", "\\");
                string[] directories = Directory.GetDirectories(fullPath);

                data.Path = fullPath;
                foreach (var dir in directories)
                {
                    DirectoryInfo info = new DirectoryInfo(dir);

                    data.Folders.Add(new ReadFolderDto()
                    {
                        Name = info.Name,
                        CreateDate = info.CreationTime,
                    });
                }

                string[] files = Directory.GetFiles(fullPath);

                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);

                    data.Files.Add(new ReadFileDto()
                    {
                        FilePath = $"/{BaseFolderName}{(string.IsNullOrEmpty(path) ? path : "")}/{info.Name}",
                        FileName=info.Name,
                        CreateDate =info.CreationTime,
                        Extension = info.Extension,
                    });
                }

                data.Folders = data.Folders.OrderBy(x => x.Name).ToList();
                data.Files = data.Files.OrderBy(x => x.FileName).ToList();
                result.SetData(data);
            }
            catch (Exception ex)
            {
                result.Fail(ex);
            }

            return result;
        }
    }
}

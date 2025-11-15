using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Dtos.Cms.FileManagers;

namespace Venus.Core.Application.Services.Models
{
    public class GetFoldersOnPathResponse
    {
        public GetFoldersOnPathResponse()
        {
            this.Folders = new List<ReadFolderDto>();
            this.Files = new List<ReadFileDto>();
        }
        public string Path { get; set; }
        public List<ReadFolderDto> Folders { get; set; }
        public List<ReadFileDto> Files { get; set; }
    }
}

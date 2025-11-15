
namespace Venus.Core.Application.Dtos.Cms.FileManagers
{
    public class ReadFileDto
    {
        public string FileName {  get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

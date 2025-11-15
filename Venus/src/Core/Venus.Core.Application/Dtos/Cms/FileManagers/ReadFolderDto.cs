
namespace Venus.Core.Application.Dtos.Cms.FileManagers
{
    public class ReadFolderDto
    {
        public ReadFolderDto()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ReadFileDto> Files { get; set; }

    }
}

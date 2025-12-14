namespace Venus.Presentation.Web.Cms.Server.Models.FileManagers
{
    public class UploadFileReq
    {
        public IFormFile File { get; set; }
        public string? Path { get; set; }
    }
}

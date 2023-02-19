//namespace ProgramAssignWebAPI.Models.Domain
//{
//    public class FileUploadModel
//    {
//    }
//}


namespace ProgramAssignWebAPI.Models
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileType FileType { get; set; }

        public int HistoryId { get; set; }
    }
}
using ProgramAssignWebAPI.Models;

namespace ProgramAssignWebAPI.Services
{
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData, FileType fileType,int HistoryId); public Task PostMultiFileAsync(List<FileUploadModel> fileData); public Task DownloadFileById(int fileName);
    }
}
using Microsoft.EntityFrameworkCore;
using ProgramAssignWebAPI.Models;
using ProgramAssignWebAPI.Data;

namespace ProgramAssignWebAPI.Services
{
    public class FileService : IFileService
    {
        private readonly AssignDbContext _dbContext;
        public FileService(AssignDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task PostFileAsync(IFormFile fileData, FileType fileType, int HistoryId)
        {
            try
            {
                var fileDetails = new FileDetails()
                {
                    ID = 0,
                    FileName = fileData.FileName,
                    FileType = fileType,
                }; using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }
                var result = _dbContext.FileDetails.Add(fileDetails);
                await _dbContext.SaveChangesAsync();

                // Link File to History Table Using HistoryId 
                var HistoryData = _dbContext.ResourceManagerAssignmentsHistory.FirstOrDefault(x => x.HistoryId == HistoryId);
                if (HistoryData != null)
                {
                    HistoryData.FileDetailsId = result.Entity.ID;
                    _dbContext.ResourceManagerAssignmentsHistory.Update(HistoryData);

                    await _dbContext.SaveChangesAsync();
                }



            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task PostMultiFileAsync(List<FileUploadModel> fileData)
        {
            try
            {
                foreach (FileUploadModel file in fileData)
                {
                    var fileDetails = new FileDetails()
                    {
                        ID = 0,
                        FileName = file.FileDetails.FileName,
                        FileType = file.FileType,
                    }; using (var stream = new MemoryStream())
                    {
                        file.FileDetails.CopyTo(stream);
                        fileDetails.FileData = stream.ToArray();
                    }
                    var result = _dbContext.FileDetails.Add(fileDetails);
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = _dbContext.FileDetails.Where(x => x.ID == Id).FirstOrDefaultAsync(); var content = new System.IO.MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                Directory.GetCurrentDirectory(), "FileDownloaded",
                file.Result.FileName); await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}



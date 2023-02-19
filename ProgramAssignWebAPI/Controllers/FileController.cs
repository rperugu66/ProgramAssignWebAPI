//using Microsoft.AspNetCore.Mvc;

//namespace ProgramAssignWebAPI.Controllers
//{
//    public class FileController
//    {

//    }
//}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramAssignWebAPI.Models;
using ProgramAssignWebAPI.Services;
namespace ProgramAssignWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _uploadService; public FileController(IFileService uploadService)
        {
            _uploadService = uploadService;
        }         /// <summary>
                          /// Single File Upload
                          /// </summary>
                          /// <param name="file"></param>
                          /// <returns></returns>
        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }
            try
            {
                await _uploadService.PostFileAsync(fileDetails.FileDetails, fileDetails.FileType,fileDetails.HistoryId);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }         /// <summary>
                          /// Multiple File Upload
                          /// </summary>
                          /// <param name="file"></param>
                          /// <returns></returns>
        [HttpPost("PostMultipleFile")]
        public async Task<ActionResult> PostMultipleFile([FromForm] List<FileUploadModel> fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }
            try
            {
                await _uploadService.PostMultiFileAsync(fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }         /// <summary>
                          /// Download File
                          /// </summary>
                          /// <param name="file"></param>
                          /// <returns></returns>
        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            try
            {
                await _uploadService.DownloadFileById(id);
               
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

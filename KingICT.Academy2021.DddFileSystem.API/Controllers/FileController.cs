using System.Collections.Generic;
using System.Threading.Tasks;
using KingICT.Academy2021.DddFileSystem.Contract;
using KingICT.Academy2021.DddFileSystem.Messaging.File;
using Microsoft.AspNetCore.Mvc;

namespace KingICT.Academy2021.DddFileSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ApiControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{folderId}")]
        public async Task<ActionResult<IEnumerable<FileView>>> Get(int folderId)
        {
            var request = CreateServiceRequest<GetFilesRequest>();

            request.FolderId = folderId;

            var response = await _fileService.GetFiles(request);

            if (response.Success)
                return Ok(response.Files);
            
            return BadResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult<FileView>> Create([FromBody] FileCreateView newFile)
        {
            var request = CreateServiceRequest<CreateFileRequest>();

            request.NewFile = newFile;

            var response = await _fileService.CreateFile(request);

            if (response.Success)
                return Ok(response.File);

            return BadResponse(response);
        }

        [HttpGet("search/{fileName}")]
        public async Task<ActionResult<IEnumerable<FileView>>> Search(string fileName)
        {
            var request = CreateServiceRequest<SearchFilesRequest>();

            request.FileName = fileName;

            var response = await _fileService.SearchFiles(request);

            if (response.Success)
                return Ok(response.Files);

            return BadResponse(response);
        }

        [HttpDelete("{folderId}/{fileId}")]
        public async Task<IActionResult> DeleteFile(int folderId, int fileId)
        {
            var request = CreateServiceRequest<DeleteFileRequest>();

            request.FolderId = folderId;
            request.FileId = fileId;

            var response = await _fileService.DeleteFile(request);

            if (response.Success)
                return NoContent();

            return BadResponse(response);
        }
    }
}

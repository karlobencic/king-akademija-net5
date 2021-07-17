using System.Collections.Generic;
using System.Threading.Tasks;
using KingICT.Academy2021.DddFileSystem.Contract;
using KingICT.Academy2021.DddFileSystem.Messaging.Folder;
using Microsoft.AspNetCore.Mvc;

namespace KingICT.Academy2021.DddFileSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ApiControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FolderView>>> Get()
        {
            var request = CreateServiceRequest<GetFoldersRequest>();

            var response = await _folderService.GetAllFolders(request);

            if (response.Success)
                return Ok(response.Folders);

            return BadResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult<FolderView>> CreateFolder([FromBody] FolderCreateView newFolder)
        {
            var request = CreateServiceRequest<CreateFolderRequest>();

            request.NewFolder = newFolder;

            var response = await _folderService.CreateFolder(request);

            if (response.Success)
                return Ok(response.Folder);

            return BadResponse(response);
        }

        [HttpPost("{parentId}")]
        public async Task<ActionResult<FolderView>> CreateSubFolder(int parentId, [FromBody] FolderCreateView newFolder)
        {
            var request = CreateServiceRequest<CreateSubFolderRequest>();

            request.ParentId = parentId;
            request.NewFolder = newFolder;

            var response = await _folderService.CreateSubFolder(request);

            if (response.Success)
                return Ok(response.SubFolder);

            return BadResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolder(int id)
        {
            var request = CreateServiceRequest<DeleteFolderRequest>();

            request.Id = id;

            var response = await _folderService.DeleteFolder(request);

            if (response.Success)
                return NoContent();

            return BadResponse(response);
        }
    }
}

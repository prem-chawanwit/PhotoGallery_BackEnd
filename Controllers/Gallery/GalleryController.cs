using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders;

namespace PhotoGallery_BackEnd.Controllers.Gallery
{

    [ApiController]
    [Route("api/[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly IGallery _gallery;
        private readonly string _uploadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backup");
        private readonly IAuthRepository _authService;
        public GalleryController(IGallery gallery, IAuthRepository authService)
        {
            _gallery = gallery;
            _authService = authService;
        }
        [Authorize]
        [HttpPost("Test")]
        public async Task<ActionResult<string>> Test([FromForm] PhotoDTO file)
        {
            if (file.requestFile == null)
            {
                return BadRequest("No file was provided.");
            }
            return Ok("OK");
        }
        [Authorize]
        [HttpPost("UploadPhoto")]
        public async Task<ActionResult<ServiceResponse<string>>> UploadPhoto([FromForm] PhotoDTO Data)
        {
            var response = await _gallery.UploadPhoto(Data);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]
        [HttpPost("EditPhotoName")]
        public async Task<ActionResult<ServiceResponse<string>>> EditPhotoName([FromForm] EditPhotoDTO Data)
        {
            var response = await _gallery.EditPhotoName(Data);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]
        [HttpPost("DeletePhotoName")]
        public async Task<ActionResult<ServiceResponse<string>>> DeletePhotoName([FromForm] EditPhotoDTO Data)
        {
            var response = await _gallery.DeletePhotoName(Data);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]
        [HttpGet("GetPhotoIdAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPhotoDTO>>>> GetAll(string username)
        {
            var response = await _gallery.GetPhotoAll(username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]
        [HttpPost("GetPhotoIdFilter")]
        public async Task<ActionResult<ServiceResponse<List<GetPhotoDTO>>>> GetFilter([FromForm] GetPhotoFilterDTO Data)
        {
            var response = await _gallery.GetPhotoFilter(Data);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetPhoto")]
        public async Task<IActionResult> GetPhoto(string filename,string username)
        {
            try
            {
                var uploadFolder = _uploadFolder;

                // Await the result of CheckUser since it's an asynchronous method
                var response = await _gallery.CheckUser(username);

                if (!response.Data) // Access Data property after awaiting response
                {
                    return Unauthorized("Cannot access photo");
                }

                // Specify the full path to the file on the server
                var filePath = Path.Combine(uploadFolder, filename);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found");
                }

                // Determine the content type based on the file extension
                var contentType = "application/octet-stream"; // You can adjust this as needed
                var fileDownloadName = Path.GetFileName(filePath);

                // Return the file as a physical file response
                return File(System.IO.File.ReadAllBytes(filePath), contentType, fileDownloadName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}


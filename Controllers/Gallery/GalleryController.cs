namespace PhotoGallery_BackEnd.Controllers.Gallery
{

    [ApiController]
    [Route("api/[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly IGallery _gallery;
        public GalleryController(IGallery gallery)
        {
            _gallery = gallery;
        }
        [HttpPost("Test")]
        public async Task<ActionResult<string>> Test([FromForm] PhotoDTO file)
        {
            if (file.requestFile == null)
            {
                return BadRequest("No file was provided.");
            }
            return Ok("OK");
        }
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
    }
}


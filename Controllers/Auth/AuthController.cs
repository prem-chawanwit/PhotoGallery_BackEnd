using Azure.Core;

namespace PhotoGallery_BackEnd.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepo;
        private IHttpContextAccessor _httpContextAccessor;
        public AuthController(IAuthRepository authRepo, IHttpContextAccessor httpContextAccessor)
        {
            _authRepo = authRepo;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("Checkuser")]
        public async Task<ActionResult<ServiceResponse<bool>>> Checkuser(string username)
        {
            var response = await _authRepo.CheckUser(username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { username = request.username }, request.password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.username, request.password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("Logout")]
        public async Task<ActionResult<ServiceResponse<int>>> Logout(string username)
        {
            var response = await _authRepo.Logout(username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("ResetPassword")]
        public async Task<ActionResult<ServiceResponse<int>>> ResetPassword(UserLoginDto request)
        {
            var response = await _authRepo.ResetPassword(request.username, request.password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<UserDto>>>> GetAllUser()
        {
            var response = await _authRepo.GetAllUser();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("DeleteUser")]
        public async Task<ActionResult<ServiceResponse<List<UserDto>>>> DeleteUser(string username)
        {
            var response = await _authRepo.DeleteUser(username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("UpdateUser")]
        public async Task<ActionResult<ServiceResponse<List<UserDto>>>> UpdateUser(string username, string accessLevelName)
        {
            var response = await _authRepo.UpdateUser(username, accessLevelName);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

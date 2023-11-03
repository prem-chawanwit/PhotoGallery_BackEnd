namespace PhotoGallery_BackEnd.Controllers.Task
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExecuteTaskController : ControllerBase
    {
        /*       
                private readonly IExcuteTaskService _excuteService;
                private readonly IConfiguration _configuration;

                public ExecuteTaskController(IExcuteTaskService excuteService, IConfiguration configuration)
                {
                    _excuteService = excuteService;
                    _configuration = configuration;
                }
                [HttpGet] // or [HttpGet], [HttpPut], etc.
                public async Task<ActionResult<ServiceResponse<string>>> OrderManager(string taskid)
                {
                    var response = await _excuteService.OrderManager(taskid);
                    if (!response.Success)
                    {
                        return BadRequest(response);
                    }
                    return Ok(response);
                }*/
    }
}

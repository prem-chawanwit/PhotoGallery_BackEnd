namespace PhotoGallery_BackEnd.Controllers.Task;
//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ViewTaskController : ControllerBase
{
/*    private readonly IViewTaskService _viewTask;

    public ViewTaskController(IViewTaskService viewTask)
    {
        this._viewTask = viewTask;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<ViewTaskDTO>>> ViewTask()
    {
        var response = await _viewTask.GetTask();
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<ViewTaskDTO>>> ViewAllTask()
    {
        var response = await _viewTask.GetAllTask();
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("GetTaskReview")]
    public async Task<ActionResult<ServiceResponse<ViewTaskDTO>>> ViewTaskReview(string taskid)
    {
        var response = await _viewTask.ViewTaskReview(taskid);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("GetSectionConvertSetting")]
    public async Task<ActionResult<ServiceResponse<TaskOrderDataDTO>>> ViewSectionConvertSetting(string taskid)
    {
        var response = await _viewTask.ViewSectionConvertSetting(taskid);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("GetLogFile")]
    public async Task<ActionResult<ServiceResponse<string>>> GetLogFile(string taskid)
    {
        var response = await _viewTask.GetLogsFile(taskid);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    //-------------------------------------------------------------
    [HttpGet("ViewAllLog")]
    public async Task<ActionResult<ServiceResponse<string>>> ViewAllLog()
    {
        var response = await _viewTask.ViewAllLog();
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("GetLogFile2")]
    public async Task<ActionResult<ServiceResponse<string>>> GetLogFile2(string logid,string program)
    {
        var response = await _viewTask.GetLogsFile2(logid, program);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("GetScheduleStatus")]
    public async Task<ActionResult<ServiceResponse<bool>>> GetScheduleStatus()
    {
        var response = await _viewTask.GetStatusSchecule();
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("IsJobRunning")]
    public async Task<ActionResult<ServiceResponse<bool>>> IsJobRunning(string jobGroup)
    {
        var response = await _viewTask.IsJobRunning(jobGroup);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("GetRunningTask")]
    public async Task<ActionResult<ServiceResponse<bool>>> IsAnyTaskRunning()
    {
        var response = await _viewTask.IsTaskRunning();
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
*/
}

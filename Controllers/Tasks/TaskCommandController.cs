namespace PhotoGallery_BackEnd.Controllers.Task
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskCommandController : ControllerBase
    {
/*       
        private readonly IExcuteTaskService _excuteService;
        private readonly IConfiguration _configuration;
        private readonly TaskDbContext _taskDbContext;
        public TaskCommandController(IExcuteTaskService excuteService, IConfiguration configuration,TaskDbContext taskDbContext)
        {
            _excuteService = excuteService;
            _taskDbContext = taskDbContext;
        }
        [HttpGet("TaskCommand")]
        public async Task<ActionResult<ServiceResponse<string>>> TaskCommand(string taskid,string process)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            if (process != "NORMAL" && process != "STOP")
            {
                response.Data = $"Your task Command {process} is not in the correct format.";
                response.success = false;
                response.message = "Server requires command 'NORMAL' or 'STOP'.";
                return BadRequest(response);
            }

            try
            {
                // Find all existing TaskCommands with the specified taskId
                var existingTaskCommands = await _taskDbContext.taskCommands
                    .Where(t => t.taskId == taskid)
                    .ToListAsync();

                if (existingTaskCommands != null && existingTaskCommands.Any())
                {
                    // Remove all existing TaskCommands
                    _taskDbContext.taskCommands.RemoveRange(existingTaskCommands);
                    await _taskDbContext.SaveChangesAsync();

                    // Reset the auto-incrementing index (identity column) to 0
                    await _taskDbContext.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('API_TaskCommand', RESEED, 0);");
                }
                else
                {
                    response.Data = $"There are no matching task IDs for '{taskid}' in the server that are running.";
                    response.success = false;
                    response.message = "Please check your taskId for correctness.";
                    return BadRequest(response);
                }

                // Create a new TaskCommand
                var tcm = new TaskCommand
                {
                    taskId = taskid, // Corrected _taskId to taskid
                    command = process // Set the command property as needed
                };

                _taskDbContext.taskCommands.Add(tcm);
                await _taskDbContext.SaveChangesAsync();
                response.Data = $"Your task Command {process} was successfully updated";
                response.success = true;
                response.message = "";

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Data = "Your task Command was not successfully updated.";
                response.success = false;
                response.message = ex.Message;
                return BadRequest(response);
            }
        }*/
    }
}

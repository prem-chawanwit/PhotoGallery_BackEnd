

namespace PhotoGallery_BackEnd.Controllers.ReportOp
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewReportController : ControllerBase
    {
/*        private readonly IReportOpService _reportOpService;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ViewReportController(IReportOpService reportOpService, IConfiguration configuration)
        {
            _reportOpService = reportOpService;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("BusinessLogicDbConnection");
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<WorkToListByResource_DTO>>>> GetWorkToListByResource(string datasetId, string orderNo)
        {
            var response = await _reportOpService.GetWorkToListByResource(datasetId, orderNo);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("WorkToListByResource")]
        public async Task<ActionResult<ReportServiceResponse<IEnumerable<WorkToListByResource_DTO>>>>GetWorkToListByResource_2(string datasetId,[FromBody] ClientRequest request)
        {
            var response = await _reportOpService.GetWorkToListByResource_2(datasetId, request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("LateOrder")]
        public async Task<ActionResult<ReportServiceResponse<IEnumerable<LateOrders_DTO>>>> GetLateOrder2(string datasetId)
        {
            var response = await _reportOpService.GetLateOrder(datasetId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        public class CustomDateConverter : IsoDateTimeConverter
        {
            public CustomDateConverter(string format)
            {
                DateTimeFormat = format;
            }
        }
        [HttpGet("MaterialUsage")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<MaterialUsage_DTO>>>> GetMaterailUsage(string datasetId)
        {
            var response = await _reportOpService.GetMaterialUsage(datasetId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("ApPlan")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ApPlan_DTO>>>> GetApPlan()
        {
            var response = await _reportOpService.GetApPlan();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        //---------------------------------------------------------------------------------------------//
        [HttpGet("WaferInput")]
        public async Task<ActionResult<ReportServiceResponse<IEnumerable<WaferInput_DTO>>>> GetWaferInput()
        {
            var response = await _reportOpService.GetWaferInput();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("Bwh")]
        public async Task<ActionResult<ReportServiceResponse<IEnumerable<Bwh_DTO>>>> GetBwh()
        {
            var response = await _reportOpService.GetBwh();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("WaferInputByLot")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<WaferInput_DTO>>>> GetWaferInputByLot(string waferLot)
        {
            var response = await _reportOpService.GetWaferInputByLot(waferLot);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("WaferInputFlag")]
        public async Task<ActionResult<ServiceResponse<string>>> SetWaferInputFlag([FromBody] WaferFlagRequestRequest requestFlag)
        {
            var response = await _reportOpService.SetWaferInputFlag(requestFlag);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("ClearWaferInputFlag")]
        public async Task<ActionResult<ServiceResponse<string>>> ClearWaferInputFlag()
        {
            var response = await _reportOpService.ClearWaferInputFlag();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        //---------------------------------------------------------------------------------------------//
        [HttpGet("DatasetId")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<DatasetId_DTO>>>> GetDatasetId()
        {
            var response = await _reportOpService.GetDatasetId();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        private async Task<ServiceResponse<string>> ExecuteSQL(string sqlQuery, string commandId)
        {
            // Replace with your actual connection string
            string connectionString = _connectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Set the command timeout to a longer duration (in seconds)
                        command.CommandTimeout = 1200; // Set to 2 minutes (adjust as needed)
                        // Execute the SQL command
                        await command.ExecuteNonQueryAsync();

                        // Return a successful response
                        return new ServiceResponse<string>
                        {
                            success = true,
                            message = $"SQL command executed successfully : Table {commandId}",
                            Data = null // You can return data if needed
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during SQL execution
                return new ServiceResponse<string>
                {
                    success = false,
                    message = $"An error occurred while executing SQL: {ex.Message} : Table {commandId}",
                    Data = null
                };
            }
        }*/
    }
}

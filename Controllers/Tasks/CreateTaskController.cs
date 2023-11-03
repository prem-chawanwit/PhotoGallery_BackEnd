namespace PhotoGallery_BackEnd.Controllers.Task;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class CreateTaskController : ControllerBase
{
/*    private readonly ICreateTaskService _createTask;
    private readonly IConfiguration _configuration;
    public CreateTaskController(ICreateTaskService createTask, IConfiguration configuration)
    {
        _createTask = createTask;
        _configuration = configuration;
    }

    [HttpPost]
    [Consumes("multipart/form-Data")]
    public async Task<ActionResult<ServiceResponse<string>>> CreateTask([FromForm] TaskOrderDataDTO Data)
    {
        var response = await _createTask.CreateTask(Data,true);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
    [HttpGet("ShortCutETL")]
    public async Task<ActionResult<ServiceResponse<string>>> ShortCutETL(int amountOfWeek)
    {
        string weekETL = "W" + amountOfWeek.ToString();
        // Check if the 'amountOfWeek' is within the allowed range [1-5].
        if (amountOfWeek < 1 || amountOfWeek > 5)
        {
            // Create a response object to indicate the error.
            ServiceResponse<string> responses = new ServiceResponse<string>();

            // Set the error message and details.
            responses.Data = "Invalid 'amountOfWeek' for ETL: " + amountOfWeek;
            responses.success = false;
            responses.message = "The server only allows 'amountOfWeek' in the range of [1-5].";

            // Return a BadRequest response with the error information.
            return BadRequest(responses);
        }else
        {
            //do nothing
        }
        #region mockupRequest
        var sectionUploadPathDataDTO = new SectionUploadPathDataDTO
        {
            dataSource = "database",
            file1 = null,
            file2 = null,
            file3 = null,
            file4 = null,
            file5 = null,
            file6 = null,
            file7 = null,
            file8 = null,
            file9 = null,
            file10 = null,
            file11 = null,
            file12 = null,
            file13 = null,
            file14 = null,
            file15 = null,
            table1 = "batch_molding",
            table2 = "branding_cure_capacity",
            table3 = "machine_master",
            table4 = "mag_mould_master",
            table5 = "magazine_master",
            table6 = "MSBPRC",
            table7 = "past_cure_capacity",
            table8 = "post_cure_capacity",
            table9 = "product_resource_data",
            table10 = "raw_mat_stock_inprocess",
            table11 = "TALPOD",
            table12 = "tray_brand_master",
            table13 = "tray_mold_master",
            table14 = "tray_test_master",
            table15 = "WIFAPP",
            table16 = "WIFBWH",
            table17 = "WIFDBL",
            table18 = "WIFDMB",
            table19 = "WIFDPF",
            table20 = "WIFDVC",
            table21 = "WIFMTS",
            table22 = "WIFPOB",
            table23 = "WIFWFS",
            table24 = "WIFWIP",
            table25 = "WIFWSC",
            table26 = "attribute_master",
            table27 = "WIFHIS",
        };
        //
        var sectionUploadSettingDataDTO = new SectionUploadSettingDataDTO
        {
            planToUpload = "A",
            planToActive = "A",
            balance = weekETL
        };
        //
        var sectionConvertSettingDataDTO = new SectionConvertSettingDataDTO
        {
            convertSetting = "convert",
            dueDate = "null",
            product = new List<string>() { "[\"createproduct\"]" }, // Initialize with an empty string
            workOrder = new List<string>() { "[\"prepareworkorder_stockwafer\",\"prepareworkorder_preparedata1\",\"prepareworkorder_preparedata2\",\"createworkorder\"]" }, // Initialize with an empty string
            apPlan = new List<string>() { "[\"createapplan\"]" }, // Initialize with an empty string,
            coProduct = new List<string>() {  "[\"createcoproduct\"]" }, // Initialize with an empty string,
            boms = new List<string>() {  "[\"createboms\"]" }, // Initialize with an empty string
        };
        //
        var data = new TaskOrderDataDTO
        {
            sectionUploadPathData = sectionUploadPathDataDTO,
            sectionUploadSettingData = sectionUploadSettingDataDTO,
            sectionConvertSettingData = sectionConvertSettingDataDTO
        };
        #endregion mockupRequest
        var response = await _createTask.CreateTask(data, false);

        if (!response.success)
        {
            return BadRequest(response);
        }
        else
        {

            // Call api example.  http://localhost:5202/api/ExecuteTask/?taskid=T_SC_20231030145350_9961
            string etlUrl = _configuration.GetSection("ETL_URL:url").Value;
            string etlPort = _configuration.GetSection("ETL_URL:port").Value;
            string etlFunction_API = "api/ExecuteTask";
            string etlFunction_Param = "?taskid="+response.Data;
            string COMBINE_ETL_URL = $"http://{etlUrl}:{etlPort}/{etlFunction_API}/{etlFunction_Param}";
            // Long-running task: Start it in the background and don't wait for it to complete.
            bool isInvoked = true;
            string reason = "";
            System.Threading.Tasks.Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = COMBINE_ETL_URL;

                    HttpResponseMessage apiResponse = await client.GetAsync(apiUrl);

                    if (apiResponse.IsSuccessStatusCode)
                    {
                        string content = await apiResponse.Content.ReadAsStringAsync();
                        // Process the response content as needed
                        // Access the properties
                        var result = JsonConvert.DeserializeObject<ServiceResponse<string>>(content);
                        string dataResponse = result.Data;
                        bool success = result.success;
                        if (success)
                        {
                            // donothing
                        }
                        else
                        {
                            reason = dataResponse;
                            isInvoked = false;
                        }
                    }
                    else
                    {
                        reason = $"API request Execute task was not successful.";
                        isInvoked = false;
                    }
                }
            });
            if (!isInvoked)
            {
                response.Data = reason;
                response.success = false;
                return Ok(response);
            }
            // Return an immediate response without waiting for the long-running task.
            response.Data = $"Create & Executed Task id = '{response.Data}', process started in the background.";
            response.success = true;
            return Ok("ETL process started in the background.");
        }
        //return Ok(response);
    }
    [HttpGet("ShortCutRetreiveActual")]
    public async Task<ActionResult<ServiceResponse<string>>> ShortCutRetreiveActual()
    {
        //
        var sectionUploadPathDataDTO = new SectionUploadPathDataDTO
        {
            dataSource = "database",
            file1 = null,
            file2 = null,
            file3 = null,
            file4 = null,
            file5 = null,
            file6 = null,
            file7 = null,
            file8 = null,
            file9 = null,
            file10 = null,
            file11 = null,
            file12 = null,
            file13 = null,
            file14 = null,
            file15 = null,
            table1 = null,
            table2 = null,
            table3 = null,
            table4 = null,
            table5 = null,
            table6 = null,
            table7 = null,
            table8 = null,
            table9 = null,
            table10 = "raw_mat_stock_inprocess",
            table11 = "TALPOD",
            table12 = null,
            table13 = null,
            table14 = null,
            table15 = null,
            table16 = "WIFBWH",
            table17 = null,
            table18 = null,
            table19 = null,
            table20 = null,
            table21 = null,
            table22 = null,
            table23 = null,
            table24 = "WIFWIP",
            table25 = null,
            table26 = null,
            table27 = "WIFHIS",
        };
        //
        var sectionUploadSettingDataDTO = new SectionUploadSettingDataDTO
        {
            planToUpload = "A",
            planToActive = "A",
            balance = "All"
        };
        //
        var sectionConvertSettingDataDTO = new SectionConvertSettingDataDTO
        {
            convertSetting = "notconvert",
            dueDate = "null",
            product = new List<string>() { "[]" }, // Initialize with an empty string
            workOrder = new List<string>() { "[]" }, // Initialize with an empty string
            apPlan = new List<string>() { "[]" }, // Initialize with an empty string,
            coProduct = new List<string>() { "[]" }, // Initialize with an empty string,
            boms = new List<string>() { "[]" }, // Initialize with an empty string
        };
        //
        var data = new TaskOrderDataDTO
        {
            sectionUploadPathData = sectionUploadPathDataDTO,
            sectionUploadSettingData = sectionUploadSettingDataDTO,
            sectionConvertSettingData = sectionConvertSettingDataDTO
        };
        var response = await _createTask.CreateTask(data,false);
        if (!response.success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }*/

}

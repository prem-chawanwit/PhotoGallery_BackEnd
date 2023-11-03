namespace PhotoGallery_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialRequireFileController : ControllerBase
    {
/*        private readonly InitialComponentDbContext dbContext;
        public InitialRequireFileController(InitialComponentDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ExcelRequireFilesDTO>>>> GetFiles()
        {
            try
            {
                var excelReferences = await dbContext.ExcelRequireFiles.ToListAsync();

                // Map the Data to RequireFilesDTO or use AutoMapper
                var requireFilesDTOs = excelReferences.Select(reference => new ExcelRequireFilesDTO
                {
                    id = reference.id,
                    tableName = reference.tableName
                }).ToList();

                var response = new ServiceResponse<List<ExcelRequireFilesDTO>> { Data = requireFilesDTOs };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ServiceResponse<List<ExcelRequireFilesDTO>>
                {
                    success = false,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }*/
    }
}

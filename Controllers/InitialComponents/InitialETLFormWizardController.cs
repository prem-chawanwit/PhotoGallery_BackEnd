namespace PhotoGallery_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialETLFormWizardController : ControllerBase
    {
/*        private readonly InitialComponentDbContext dbContext;
        public InitialETLFormWizardController(InitialComponentDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpGet("GetRequireTables")]
        public async Task<ActionResult<ServiceResponse<List<DatabaseRequireTablesDTO>>>> GetRequireTables()
        {
            try
            {
                var tablesReferences = await dbContext.TableRequire.ToListAsync();

                // Map the Data to RequireFilesDTO or use AutoMapper
                var requireTablesDTOs = tablesReferences.Select(reference => new DatabaseRequireTablesDTO
                {
                    id = reference.id,
                    tableName = reference.tableName,
                    tableNameDetails = reference.tableName_Detail
                }).ToList();

                var response = new ServiceResponse<List<DatabaseRequireTablesDTO>> { Data = requireTablesDTOs };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ServiceResponse<List<DatabaseRequireTablesDTO>>
                {
                    success = false,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }
        [HttpGet("GetRequireFiles")]
        public async Task<ActionResult<ServiceResponse<List<ExcelRequireFilesDTO>>>> GetRequireFiles()
        {
            try
            {
                var excelReferences = await dbContext.ExcelRequireFiles.ToListAsync();

                // Map the Data to RequireFilesDTO or use AutoMapper
                var requireFilesDTOs = excelReferences.Select(reference => new ExcelRequireFilesDTO
                {
                    id = reference.id,
                    tableName = reference.tableName,
                    tableNameDetails = reference.tableName_Detail
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
        }
        [HttpGet("GetRequirePlan")]
        public async Task<ActionResult<ServiceResponse<List<PlansDTO>>>> GetRequirePlan()
        {
            try
            {
                var planReferences = await dbContext.Plans.ToListAsync();
                var requirePlansDTOs = planReferences.Select(reference => new PlansDTO
                {
                    id = reference.id,
                    planToUpload = reference.planToUpload,
                    planToActive = reference.planToActive,
                    planDetails = reference.planDetails
                }).ToList();
                var response = new ServiceResponse<List<PlansDTO>> { Data = requirePlansDTOs };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ServiceResponse<List<PlansDTO>>
                {
                    success = false,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }
        [HttpGet("GetRequireBalance")]
        public async Task<ActionResult<ServiceResponse<List<BalanceDTO>>>> GetBalance()
        {
            try
            {
                var planReferences = await dbContext.Balance.ToListAsync();
                var requireBalanceDTOs = planReferences.Select(reference => new BalanceDTO
                {
                    id = reference.id,
                    balance = reference.balance
                }).ToList();
                var response = new ServiceResponse<List<BalanceDTO>> { Data = requireBalanceDTOs };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ServiceResponse<List<BalanceDTO>>
                {
                    success = false,
                    message = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }*/
    }
}

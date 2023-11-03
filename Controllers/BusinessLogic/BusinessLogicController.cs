namespace PhotoGallery_BackEnd.Controllers.BusinessLogic
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessLogicController : ControllerBase
    {
/*        private readonly ITableService _tableService;
        private readonly ITranformService _tranFromService;
        public BusinessLogicController(ITableService tableService, ITranformService tranFromService)
        {
            _tableService = tableService;
            _tranFromService = tranFromService;
        }
        [HttpGet("TranformProduct")]
        public async Task<ActionResult<ServiceResponse<string>>> TranformProduct(string plan,bool isActive)
        {
            var response = await _tranFromService.TranformProduct("-", plan,isActive);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("TranformStockWafer")]
        public async Task<ActionResult<ServiceResponse<string>>> TranformStockWafer(string plan, bool isActive)
        {
            var response = await _tranFromService.TranformStockWafer("-", plan, isActive);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("ClearPlan")]
        public async Task<ActionResult<ServiceResponse<string>>> ClearPlan(string plan)
        {
            var response = await _tableService.ClearAllTablesByUploadPlan(plan);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }*/
    }
}

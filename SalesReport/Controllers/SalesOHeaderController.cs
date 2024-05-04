using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesOHeaderController : Controller
    {
        private readonly ISalesOHeaderService _service;

        public SalesOHeaderController(ISalesOHeaderService service)
        {
            _service = service;
        }
        /// <summary>
        /// This method return all details about sales report
        /// </summary>
        /// <returns>All details about sales report</returns>
        /// <response code="200">All records were correctly obtained</response>
        /// <response code="404">There are no records</response>
        /// /// <response code="401">No authorization</response>
        [HttpGet("GetAll/years")]
        [ProducesResponseType(typeof(SalesOHeaderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<SalesOHeaderDto>>> GetAllYears()
        {
            var years = await _service.GetAllYears();
            return Ok(years);
        }
        /// <summary>
        /// This method return all vendor with filter
        /// </summary>
        /// <returns>All vendor names and theirs sales</returns>
        /// <response code="200">All records were correctly obtained</response>
        /// <response code="404">There are no records</response>
        /// /// <response code="401">No authorization</response>
        [HttpGet("vendor/filter")]
        [ProducesResponseType(typeof(SalesPersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<SalesPersonDto>>> GetSalesPersonDetails([FromQuery] SalesPersonfilterDto filter)
        {
            var years = await _service.GetSalesPersonDetails(filter);
            return Ok(years);
        }
        /// <summary>
        /// This method return all vendor
        /// </summary>
        /// <returns>All vendor names and theirs sales</returns>
        /// <response code="200">All records were correctly obtained</response>
        /// <response code="404">There are no records</response>
        /// /// <response code="401">No authorization</response>
        [HttpGet("vendor")]
        [ProducesResponseType(typeof(SalesPersonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<SalesPersonDto>>> GetSalesPerson()
        {
            var years = await _service.GetSalesPerson();
            return Ok(years);
        }
    }
}

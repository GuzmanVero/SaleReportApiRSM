using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace SalesReport.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesPersonNameController : ControllerBase
    {
        private readonly ISalesPersonNameService _service;

        public SalesPersonNameController(ISalesPersonNameService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all names of Sales employees
        /// </summary>
        /// <returns>Returns the list of Employee name</returns>
        /// <response code="200">Names found</response>
        /// <response code="404">Nmes not found</response>
        /// <response code="401">No authorization</response>
        [HttpGet("GetAll/salesPersonName")]
        [ProducesResponseType(typeof(SalesPersonNameDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<SalesPersonNameDto>>> GetAllSalesPersonName()
        {
            var salesPersonName = await _service.GetAllSalesPersonName();
            return Ok(salesPersonName);
        }
    }
}

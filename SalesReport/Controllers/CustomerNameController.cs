using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerNameController : ControllerBase
    {
        private readonly ICustomerNameService _service;

        public CustomerNameController(ICustomerNameService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all names of customers
        /// </summary>
        /// <returns>Returns the list of Customer name</returns>
        /// <response code="200">Names found</response>
        /// <response code="404">Nmes not found</response>
        /// <response code="401">No authorization</response>
        [HttpGet("GetAll/customerName")]
        [ProducesResponseType(typeof(customerNameDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<customerNameDto>>> GetAllCustomerName()
        {
            var customerName = await _service.GetAllCustomerName();
            return Ok(customerName);
        }
    }
}

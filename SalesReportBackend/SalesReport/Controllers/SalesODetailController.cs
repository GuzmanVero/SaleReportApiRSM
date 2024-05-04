using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;
using SalesReport.Domain.Models;

namespace SalesReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class SalesODetailController : Controller
    {
        private readonly ISalesODetailService _service;

        public SalesODetailController(ISalesODetailService service)
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
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<SalesOrderDetailDto>>> GetSalesOrderDetails()
        {
            var orderDetails = await _service.GetSalesOrderDetailsAsync();
            return Ok(orderDetails);
        }
        /// <summary>
        /// This method return all details with a spesific year
        /// </summary>
        /// <param name="year">Year obtained from date of orderdate</param>
        /// <returns>All data filtered by year</returns>
        /// <response code="200">All records were correctly obtained</response>
        /// <response code="404">There are no records</response>
        /// <response code="401">No authorization</response>
        [HttpGet("details/{year}")]
        [ProducesResponseType(typeof(SalesOrderDetailDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSalesDetails(int year)
        {
            var years = await _service.GetSalesOrderDetailsByYear(year);
            return Ok(years);
        }
        /// <summary>
        /// This method return all details filtered by year, ProductCategoryName, EmployeeName or CustomerName
        /// </summary>
        /// <param name="filter">In both names you can search for likes</param>
        /// <returns>All details about sales report</returns>
        /// <response code="200">All records were correctly obtained</response>
        /// <response code="404">There are no records</response>
        /// <response code="401">No authorization</response>
        [HttpGet("details/filters")]
        [ProducesResponseType(typeof(SalesOrderDetailDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSalesDetails([FromQuery] SalesFilterDto filter)
        {
            var dataFiter = await _service.GetSalesOrderDetailsByFilters(filter);
            return Ok(dataFiter);
        }


    }
}

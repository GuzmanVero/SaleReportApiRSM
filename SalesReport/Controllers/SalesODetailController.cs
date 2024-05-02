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
    [Authorize]
    public class SalesODetailController : Controller
    {
        private readonly ISalesODetailService _service;

        public SalesODetailController(ISalesODetailService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SalesOrderDetailDto>>> GetSalesOrderDetails()
        {
            var orderDetails = await _service.GetSalesOrderDetailsAsync();
            return Ok(orderDetails);
        }

        [HttpGet("details/{year}")]
        public async Task<IActionResult> GetSalesDetails(int year)
        {
            var years = await _service.GetSalesOrderDetailsByYear(year);
            return Ok(years);
        }
        [HttpGet("details/filters")]
        public async Task<IActionResult> GetSalesDetails([FromQuery] SalesFilterDto filter)
        {
            var dataFiter = await _service.GetSalesOrderDetailsByFilters(filter);
            return Ok(dataFiter);
        }


    }
}

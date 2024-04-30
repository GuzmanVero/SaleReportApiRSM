using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;
using SalesReport.Domain.Models;

namespace SalesReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
    }
}

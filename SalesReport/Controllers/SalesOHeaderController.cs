using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Controllers
{
    public class SalesOHeaderController : Controller
    {
        private readonly ISalesOHeaderService _service;

        public SalesOHeaderController(ISalesOHeaderService service)
        {
            _service = service;
        }

        [HttpGet("GetAll/years")]
        public async Task<ActionResult<List<SalesOHeaderDto>>> GetAllYears()
        {
            var years = await _service.GetAllYears();
            return Ok(years);
        }
    }
}

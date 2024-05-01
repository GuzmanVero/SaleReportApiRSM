using Microsoft.AspNetCore.Mvc;
using SalesReport.Application.Dtos;
using SalesReport.Domain.interfaces;

namespace SalesReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _service;

        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAll/ProductName")]
        public async Task<ActionResult<List<ProductCategoryDto>>> GetAllProductName()
        {
            var productName = await _service.GetAllProductName();
            return Ok(productName);
        }
    }
}

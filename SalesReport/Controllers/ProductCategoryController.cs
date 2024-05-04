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
        /// <summary>
        /// Get all product category names
        /// </summary>
        /// <returns>Returns the list of category names without repeats</returns>
        /// <response code="200">Category name of profuct found</response>
        /// <response code="404">Category name of profuct found</response>
        /// <response code="401">No authorization</response>
        [HttpGet("GetAll/ProductName")]
        [ProducesResponseType(typeof(ProductCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<ProductCategoryDto>>> GetAllProductName()
        {
            var productName = await _service.GetAllProductName();
            return Ok(productName);
        }
    }
}

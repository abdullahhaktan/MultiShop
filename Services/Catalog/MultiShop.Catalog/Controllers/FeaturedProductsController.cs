using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeaturedProductDtos;
using MultiShop.Catalog.Services.FeaturedProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedProductsController : ControllerBase
    {
        private readonly IFeaturedProductService _productService;

        public FeaturedProductsController(IFeaturedProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> FeaturedProductList()
        {
            var values = await _productService.GetAllFeaturedProductsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeaturedProductById(string id)
        {
            var value = await _productService.GetFeaturedProductByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedProduct(CreateFeaturedProductDto createFeaturedProductDto)
        {
            await _productService.CreateFeaturedProductAsync(createFeaturedProductDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeaturedProduct(string id)
        {
            await _productService.DeleteFeaturedProductAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeaturedProduct(UpdateFeaturedProductDto updateFeaturedProductDto)
        {
            await _productService.UpdateFeaturedProductAsync(updateFeaturedProductDto);
            return Ok(updateFeaturedProductDto);
        }
    }
}
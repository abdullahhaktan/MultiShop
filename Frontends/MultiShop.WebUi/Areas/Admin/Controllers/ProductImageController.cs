using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductImageDtos;
using MultiShop.WebUi.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Ürün Görsel İşlemleri";
            HttpContext.Items["v0"] = "Ürün Görsel Listesi";
            HttpContext.Items["v2"] = "/Admin/ProductImage/Index";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await getRoutingsAsync();
            var values = await _productImageService.GetAllProductImageAsync();

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
        {
            try
            {
                await getRoutingsAsync();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage([FromForm] CreateProductImageDto createProductImageDto)
        {
            try
            {
                if (createProductImageDto == null)
                    return View("Error");

                await _productImageService.CreateProductImageAsync(createProductImageDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteProductImage(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _productImageService.DeleteProductImageAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();

                var value = await _productImageService.GetProductImageByIdAsync(id);
                if (value == null)
                    return View("Error");

                return View(value);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            try
            {
                if (updateProductImageDto == null)
                    return View("Error");

                await _productImageService.UpdateProductImageAsync(updateProductImageDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDetailDtos;
using MultiShop.WebUi.Services.CatalogServices.PrdoductDetailServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Özel Teklif İşlemleri";
            HttpContext.Items["v0"] = "Özel Teklif Listesi";
            HttpContext.Items["v2"] = "/Admin/ProductDetail/Index";
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            await getRoutingsAsync();
            var values = await _productDetailService.GetProductDetailByIdAsync(id);

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductDetail()
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


        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();

                var value = await _productDetailService.GetProductDetailByIdAsync(id);
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
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            try
            {
                if (updateProductDetailDto == null)
                    return View("Error");

                await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}

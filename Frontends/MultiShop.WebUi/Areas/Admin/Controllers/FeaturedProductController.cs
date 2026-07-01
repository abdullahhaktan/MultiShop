using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.FeaturedProductsDtos;
using MultiShop.WebUi.Services.CatalogServices.FeaturedProductServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturedProductController : Controller
    {
        private readonly IFeaturedProductService _featuredProductService;

        public FeaturedProductController(IFeaturedProductService featuredProductService)
        {
            _featuredProductService = featuredProductService ?? throw new ArgumentNullException(nameof(featuredProductService));
        }

        private async Task getRoutingsAsync()
        {
            try
            {
                HttpContext.Items["v0"] = "Ürün Özellik İşlemleri";
                HttpContext.Items["v1"] = "Ürün Özellik Listesi";
                HttpContext.Items["v2"] = "/Admin/FeaturedProduct/Index";
            }
            catch (Exception ex)
            {
                throw new Exception("getRoutingsAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                await getRoutingsAsync();

                var values = await _featuredProductService.GetAllFeaturedProductAsync();
                if (values == null)
                    return View(new List<ResultFeaturedProductDto>());

                return View(values);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeaturedProduct()
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
        public async Task<IActionResult> CreateFeaturedProduct(CreateFeaturedProductDto createFeaturedProductDto)
        {
            try
            {
                if (createFeaturedProductDto == null)
                    return View("Error");

                await _featuredProductService.CreateFeaturedProductAsync(createFeaturedProductDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteFeaturedProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _featuredProductService.DeleteFeaturedProductAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeaturedProduct(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();
                var value = await _featuredProductService.GetFeaturedProductByIdAsync(id);
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
        public async Task<IActionResult> UpdateFeaturedProduct(UpdateFeaturedProductDto updateFeaturedProductDto)
        {
            try
            {
                if (updateFeaturedProductDto == null)
                    return View("Error");

                await _featuredProductService.UpdateFeaturedProductAsync(updateFeaturedProductDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}

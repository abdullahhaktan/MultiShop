using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BrandDtos;
using MultiShop.WebUi.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        private async Task getRoutingsAsync()
        {
            try
            {
                HttpContext.Items["v0"] = "Marka İşlemleri";
                HttpContext.Items["v1"] = "Marka Listesi";
                HttpContext.Items["v2"] = "/Admin/Brand/Index";
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

                var values = await _brandService.GetAllBrandAsync();
                if (values == null)
                    return View(new List<ResultBrandDto>());

                return View(values);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateBrand()
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
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            try
            {
                if (createBrandDto == null)
                    return View("Error");

                await _brandService.CreateBrandAsync(createBrandDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _brandService.DeleteBrandAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();
                var value = await _brandService.GetBrandByIdAsync(id);
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
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            try
            {
                if (updateBrandDto == null)
                    return View("Error");

                await _brandService.UpdateBrandAsync(updateBrandDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}

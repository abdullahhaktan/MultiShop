using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.FeatureDtos;
using MultiShop.WebUi.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService ?? throw new ArgumentNullException(nameof(featureService));
        }

        private async Task getRoutingsAsync()
        {
            try
            {
                HttpContext.Items["v0"] = "Özellik İşlemleri";
                HttpContext.Items["v1"] = "Özellik Listesi";
                HttpContext.Items["v2"] = "/Admin/Feature/Index";
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

                var values = await _featureService.GetAllFeatureAsync();
                if (values == null)
                    return View(new List<ResultFeatureDto>());

                return View(values);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeature()
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
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            try
            {
                if (createFeatureDto == null)
                    return View("Error");

                await _featureService.CreateFeatureAsync(createFeatureDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _featureService.DeleteFeatureAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();
                var value = await _featureService.GetFeatureByIdAsync(id);
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
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            try
            {
                if (updateFeatureDto == null)
                    return View("Error");

                await _featureService.UpdateFeatureAsync(updateFeatureDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}

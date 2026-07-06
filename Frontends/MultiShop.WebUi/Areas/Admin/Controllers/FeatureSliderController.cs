using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.FeatureSliderDtos;
using MultiShop.WebUi.Services.CatalogServices.FeatureSliderServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        private async Task getRoutingsAsync()
        {
            try
            {
                HttpContext.Items["v0"] = "Slayt İşlemleri";
                HttpContext.Items["v1"] = "Slayt Listesi";
                HttpContext.Items["v2"] = "/Admin/FeatureSlider/Index";
            }
            catch (Exception ex)
            {
                throw new Exception("getRoutingsAsync işlemi sırasında bir hata oluştu.", ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await getRoutingsAsync();

            try
            {
                await getRoutingsAsync();
                var values = await _featureSliderService.GetAllFeatureSliderAsync();
                if (values == null)
                    return View(new List<ResultFeatureSliderDto>());

                return View(values);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeatureSlider()
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
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            try
            {
                if (createFeatureSliderDto == null)
                    return View("Error");

                await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _featureSliderService.DeleteFeatureSliderAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();

                var value = await _featureSliderService.GetFeatureSliderByIdAsync(id);
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
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            try
            {
                if (updateFeatureSliderDto == null)
                    return View("Error");

                await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}

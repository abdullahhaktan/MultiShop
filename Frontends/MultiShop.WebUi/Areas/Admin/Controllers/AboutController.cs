using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.AboutDtos;
using MultiShop.WebUi.Services.CatalogServices.AboutServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService ?? throw new ArgumentNullException(nameof(aboutService));
        }

        private async Task getRoutingsAsync()
        {
            try
            {
                HttpContext.Items["v0"] = "Hakkımda İşlemleri";
                HttpContext.Items["v1"] = "Hakkımda";
                HttpContext.Items["v2"] = "/Admin/About/Index";
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

                var value = await _aboutService.GetAboutByIdAsync();
                if (value == null)
                    return View(new GetAboutByIdDto());

                return View(value);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateAbout()
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
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            try
            {
                if (createAboutDto == null)
                    return View("Error");

                await _aboutService.CreateAboutAsync(createAboutDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _aboutService.DeleteAboutAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();
                var value = await _aboutService.GetAboutByIdAsync();
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
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            try
            {
                if (updateAboutDto == null)
                    return View("Error");

                await _aboutService.UpdateAboutAsync(updateAboutDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}

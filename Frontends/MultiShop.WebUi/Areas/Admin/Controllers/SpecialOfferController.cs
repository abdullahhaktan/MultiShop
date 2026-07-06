using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.SpecialOfferDtos;
using MultiShop.WebUi.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Özel Teklif İşlemleri";
            HttpContext.Items["v0"] = "Özel Teklif Listesi";
            HttpContext.Items["v2"] = "/Admin/SpecialOffer/Index";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await getRoutingsAsync();
            var values = await _specialOfferService.GetAllSpecialOfferAsync();

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSpecialOffer()
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
        public async Task<IActionResult> CreateSpecialOffer([FromForm] CreateSpecialOfferDto createSpecialOfferDto)
        {
            try
            {
                if (createSpecialOfferDto == null)
                    return View("Error");

                await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _specialOfferService.DeleteSpecialOfferAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();

                var value = await _specialOfferService.GetSpecialOfferByIdAsync(id);
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
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            try
            {
                if (updateSpecialOfferDto == null)
                    return View("Error");

                await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}

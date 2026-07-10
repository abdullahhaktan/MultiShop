using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ContactDtos;
using MultiShop.WebUi.Services.CatalogServices.ContactServices;

namespace MultiShop.WebUi.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "İletişim";
            HttpContext.Items["a0"] = "/Default/Index";
        }

        public async Task<IActionResult> Index()
        {
            await getRoutingsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createContactDto);
            }

            try
            {
                await _contactService.CreateContactAsync(createContactDto);

                return RedirectToAction("Index", "Contact");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu: " + ex.Message);
                return View(createContactDto);
            }
        }
    }
}

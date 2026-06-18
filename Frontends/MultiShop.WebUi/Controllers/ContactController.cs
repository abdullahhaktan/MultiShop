using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class ContactController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "İletişim";
            HttpContext.Items["a0"] = "/Default/Index";

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class ShoppingCartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Sepet";
            HttpContext.Items["a0"] = "/Default/Index";

            return View();
        }
    }
}

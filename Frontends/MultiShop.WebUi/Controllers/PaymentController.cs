using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class PaymentController : Controller
    {
        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Ödeme Ekranı";
            HttpContext.Items["a0"] = "/Default/Index";
        }

        public async Task<IActionResult> Index()
        {
            await getRoutingsAsync();
            return View();
        }
    }
}

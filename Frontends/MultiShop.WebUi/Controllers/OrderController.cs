using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MultiShop.WebUi.Controllers
{
    public class OrderController : Controller
    {
        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Sipariş";
            HttpContext.Items["a0"] = "/Default/Index";

        }

        public async Task<IActionResult> Index()
        {
            await getRoutingsAsync();
            return View();
        }
    }
}

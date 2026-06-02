using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class ShoppingCartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

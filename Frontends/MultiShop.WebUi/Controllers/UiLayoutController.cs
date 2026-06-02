using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class UiLayoutController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

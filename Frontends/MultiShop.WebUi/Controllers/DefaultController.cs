using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Ana Sayfa";
            var user = User.Claims;
            int x;
            return View();
        }
    }
}

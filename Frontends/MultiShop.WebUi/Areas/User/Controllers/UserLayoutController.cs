using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Areas.User.Controllers
{
    public class UserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

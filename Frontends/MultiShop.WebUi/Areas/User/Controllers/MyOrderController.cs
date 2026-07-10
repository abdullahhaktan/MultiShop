using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        public IActionResult MyOrderList()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.Interfaces;

namespace MultiShop.WebUi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfoAsync();
            return View(values);
        }
    }
}

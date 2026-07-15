using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.UserIdentityServices;
using System.Threading.Tasks;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _uerIdentityService;

        public UserController(IUserIdentityService uerIdentityService)
        {
            _uerIdentityService = uerIdentityService;
        }

        public async Task<IActionResult> UserList()
        {
            var values = await _uerIdentityService.GetAllUserListAsync();
            return View(values);
        }
    }
}

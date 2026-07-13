using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.OrderServices.OrderingServices;
using System;
using System.Threading.Tasks;

namespace MultiShop.WebUi.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderOrderingService orderOrderingService, IUserService userService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            try
            {
                var user = await _userService.GetUserInfo();

                if (user == null || string.IsNullOrEmpty(user.Id))
                {
                    TempData["ErrorMessage"] = "Kullanıcı bilgilerinize erişilemedi. Lütfen tekrar giriş yapın.";
                    return RedirectToAction("Index", "Login", new { area = "" });
                }

                var values = await _orderOrderingService.GetOrderingByUserId(user.Id);

                if (values == null)
                {
                    values = new List<DtoLayer.OrderDtos.OrderOrderingDtos.ResultOrderingByUserIdDto>();
                }

                return View(values);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Siparişleriniz yüklenirken bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                return View(new List<DtoLayer.OrderDtos.OrderOrderingDtos.ResultOrderingByUserIdDto>());
            }
        }
    }
}
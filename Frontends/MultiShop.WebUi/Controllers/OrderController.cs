using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUi.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService orderService, IUserService userService)
        {
            _orderAddressService = orderService;
            _userService = userService;
        }

        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Sipariş";
            HttpContext.Items["a0"] = "/Default/Index";

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await getRoutingsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;
            createOrderAddressDto.Description = "aa";

            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}

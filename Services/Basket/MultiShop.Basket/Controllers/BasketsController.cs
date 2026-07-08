using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;
            var value = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            Console.WriteLine("SaveMyBasket çalıştı");

            basketTotalDto.UserId = _loginService.GetUserId;

            Console.WriteLine($"UserId = {basketTotalDto.UserId}");

            await _basketService.SaveBasket(basketTotalDto);

            return Ok("Sepetteki değişiklikler kaydedildi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet başarıyla silindi");
        }
    }
}

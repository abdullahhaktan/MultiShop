using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.BasketServices;
using MultiShop.WebUi.Services.DiscountServices;

namespace MultiShop.WebUi.Controllers
{
    public class DiscountCouponController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;


        public DiscountCouponController(IDiscountService discountService,IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon([FromForm]string couponCode)
        {
            var values = await _discountService.GetDiscountCouponCountRate(couponCode);

            var basketValues = await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 10;

            var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);

            return RedirectToAction("Index", "ShoppingCart", new { couponCode = couponCode, discountRate = values, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}

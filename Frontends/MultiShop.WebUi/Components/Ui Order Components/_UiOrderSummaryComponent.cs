using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.BasketServices;

namespace MultiShop.WebUi.Components.Ui_Order_Components
{
    public class _UiOrderSummaryComponent : ViewComponent
    {
        private readonly IBasketService _basketService;
        public _UiOrderSummaryComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.BasketServices;

namespace MultiShop.WebUi.Components.Ui_ShoppingCart_Components
{
    public class _UiShoppingCartProductListComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _UiShoppingCartProductListComponent(IBasketService basketService)
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

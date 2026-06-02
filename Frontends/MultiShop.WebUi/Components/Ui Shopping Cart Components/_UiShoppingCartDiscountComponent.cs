using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Shopping_Cart_Components
{
    public class _UiShoppingCartDiscountComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

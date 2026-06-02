using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_ShoppingCart_Components
{
    public class _UiShoppingCartProductListComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

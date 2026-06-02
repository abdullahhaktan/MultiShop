using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Product_Components
{
    public class _UiProductListComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

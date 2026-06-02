using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiRelatedProductsComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.UiLayout_Components
{
    public class _UiLayoutFeaturedProductComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

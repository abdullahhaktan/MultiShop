using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.UiLayout_Components
{
    public class _UiLayoutTobBarComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

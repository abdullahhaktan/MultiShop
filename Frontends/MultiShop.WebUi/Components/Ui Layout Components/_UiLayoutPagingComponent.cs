using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.UiLayout_Components
{
    public class _UiLayoutPagingComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

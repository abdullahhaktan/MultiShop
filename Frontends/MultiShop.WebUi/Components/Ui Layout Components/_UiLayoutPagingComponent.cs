using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Layout_Components
{
    public class _UiLayoutPagingComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

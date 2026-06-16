using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Layout_Components
{
    public class _UiLayoutContactComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

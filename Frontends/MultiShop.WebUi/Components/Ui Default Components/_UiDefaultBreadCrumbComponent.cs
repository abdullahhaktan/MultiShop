using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Default_Components
{
    public class _UiDefaultBreadCrumbComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

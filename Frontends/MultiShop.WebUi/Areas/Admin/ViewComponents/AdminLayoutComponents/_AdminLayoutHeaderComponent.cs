using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutHeaderComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

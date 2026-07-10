using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Areas.User.Components.UserLayoutComponents
{
    public class _UserLayoutNavbarComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

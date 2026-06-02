using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Common_Components
{
    public class _UiBreadCrumbComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

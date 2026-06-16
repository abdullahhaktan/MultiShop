using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Common_Components
{
    public class _UiBreadCrumbComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v0 = HttpContext.Items["v0"]?.ToString();
            ViewBag.v1 = HttpContext.Items["v1"]?.ToString();
            ViewBag.v2 = HttpContext.Items["v2"]?.ToString();

            return View();
        }
    }
}

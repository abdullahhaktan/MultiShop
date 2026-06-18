using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Contact_Components
{
    public class _UiContactBreadCrumbComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v0 = HttpContext.Items["v0"]?.ToString();
            ViewBag.v1 = HttpContext.Items["v1"]?.ToString();
            ViewBag.a0 = HttpContext.Items["a0"]?.ToString();

            return View();
        }
    }
}

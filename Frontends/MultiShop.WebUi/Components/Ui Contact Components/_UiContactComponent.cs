using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Contact_Components
{
    public class _UiContactComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

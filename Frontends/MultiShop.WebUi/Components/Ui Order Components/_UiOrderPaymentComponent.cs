using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Components.Ui_Order_Components
{
    public class _UiOrderPaymentComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

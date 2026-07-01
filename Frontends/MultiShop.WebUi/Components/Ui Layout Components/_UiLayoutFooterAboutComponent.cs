using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.AboutServices;

namespace MultiShop.WebUi.Components.Ui_Layout_Components
{
    public class _UiLayoutFooterAboutComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _UiLayoutFooterAboutComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _aboutService.GetAboutByIdAsync();
            return View(value);
        }
    }
}

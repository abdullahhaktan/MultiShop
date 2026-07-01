using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUi.Components.Ui_Default_Components
{
    public class _UiDefaultBrandComponent : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _UiDefaultBrandComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
    }
}

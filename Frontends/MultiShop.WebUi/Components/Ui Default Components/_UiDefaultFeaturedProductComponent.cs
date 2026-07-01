using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.FeaturedProductServices;

namespace MultiShop.WebUi.Components.Ui_Default_Components
{
    public class _UiDefaultFeaturedProductComponent : ViewComponent
    {
        private readonly IFeaturedProductService _featuredProductService;

        public _UiDefaultFeaturedProductComponent(IFeaturedProductService featuredProductService)
        {
            _featuredProductService = featuredProductService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featuredProductService.GetAllFeaturedProductAsync();

            return View(values);
        }
    }
}

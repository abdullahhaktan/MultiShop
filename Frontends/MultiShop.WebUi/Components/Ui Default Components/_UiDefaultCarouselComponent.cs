using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.Catalog_Services.FeatureSliderServices;

namespace MultiShop.WebUi.Components.Ui_Default_Components
{
    public class _UiDefaultCarouselComponent : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _UiDefaultCarouselComponent(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();

            return View(values);
        }
    }
}

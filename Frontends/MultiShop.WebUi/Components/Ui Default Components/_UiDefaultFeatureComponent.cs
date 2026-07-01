using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUi.Components.Ui_Default_Components
{
    public class _UiDefaultFeatureComponent : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _UiDefaultFeatureComponent(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}

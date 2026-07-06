using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUi.Components.Ui_Default_Components
{
    public class _UiDefaultSpecialOfferComponent1 : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _UiDefaultSpecialOfferComponent1(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();

            return View(values);
        }
    }
}

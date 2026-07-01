using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.PrdoductDetailServices;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiProductDetailAdditionalInformationComponent : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _UiProductDetailAdditionalInformationComponent(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productDetail = await _productDetailService.GetProductDetailByIdAsync(id);
            return View(productDetail);
        }
    }
}

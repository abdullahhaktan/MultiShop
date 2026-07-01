using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDetailDtos;
using MultiShop.WebUi.Services.CatalogServices.PrdoductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiProductDetailDescriptionComponent : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _UiProductDetailDescriptionComponent(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productDetail = await _productDetailService.GetProductDetailByIdAsync(id);

            if (productDetail != null)
            {
                return View(productDetail);
            }

            return View();
        }
    }
}

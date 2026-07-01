using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDetailDtos;
using MultiShop.WebUi.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiProductDetailImageComponent : ViewComponent
    {
        private readonly IProductImageService _productImageService;

        public _UiProductDetailImageComponent(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            // 1. productId boşsa hiç API'yi yorma
            if (string.IsNullOrEmpty(productId))
            {
                return View(new GetProductImageByIdDto()); // Return an empty object so that the model does not return a null reference
            }

            var productImageId = await _productImageService.GetProductImageIdByProductIdAsync(productId);

            var productImage = await _productImageService.GetProductImageByIdAsync(productImageId);

            return View(productImage);
        }
    }
}

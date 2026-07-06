using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ProductDtos;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUi.Components.Ui_Product_Components
{
    public class _UiProductListComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public _UiProductListComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var responseMessage = new HttpResponseMessage();
            var values = new List<ResultProductWithCategoryDto>();

            if (categoryId != null)
            {
                values = await _productService.GetAllProductWithCategoryByCategoryIdAsync(categoryId);
                return View(values);
            }

            else
            {
                var values1 = new List<ResultProductWithCategoryDto>();
                var allProducts = await _productService.GetAllProductAsync();
                foreach (var item in allProducts)
                {
                    values1.Add(new ResultProductWithCategoryDto
                    {
                        Id = item.Id,
                        ProductName = item.ProductName,
                        Price = item.Price,
                        OldPrice = item.OldPrice,
                        Stock = item.Stock,
                        ImageUrl = item.ImageUrl,
                        Description = item.Description,
                        CategoryId = item.CategoryId
                    });
                }

                return View(values1);
            }
        }
    }
}

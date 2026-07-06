using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;
using MultiShop.WebUi.Services.CatalogServices.UserCommentServices;

namespace MultiShop.WebUi.Components.Ui_Product_Detail_Components
{
    public class _UiUserCommentComponent : ViewComponent
    {
        private readonly IUserCommentService _userCommentService;
        private readonly IProductService _productService;

        public _UiUserCommentComponent(IUserCommentService userCommentService, IProductService productService)
        {
            _userCommentService = userCommentService;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var values = await _userCommentService.GetUserCommentsByProductIdAsync(productId);
            string id = productId;
            var product = await _productService.GetProductByIdAsync(id);

            if (product != null)
            {
                ViewBag.Product = product.ProductName;
            }

            else
            {
                ViewBag.Product = "Ürün bulunamadı";
            }

            return View(values);
        }
    }
}

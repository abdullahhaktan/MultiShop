using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUi.Controllers
{
    public class DefaultController(IProductService _productService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Ana Sayfa";
            var user = User.Claims;
            int x;
            return View();
        }

        public async Task<IActionResult> GetProductIdByProductName(string productName)
        {
            var value = await _productService.GetProductIdByProductNameAsync(productName);
            return RedirectToAction("AddBasketItem", "ShoppingCart", new { id = value });
        }
    }
}

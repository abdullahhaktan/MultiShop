 using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUi.Services.BasketServices;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUi.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Ürün İşlemleri";
            HttpContext.Items["v2"] = "Ürün Listesi";

            HttpContext.Items["a0"] = "/Default/Index";
            HttpContext.Items["a1"] = "/ProductList/Index";
        }


        public async Task<IActionResult> Index(string couponCode, int discountRate, decimal totalNewPriceWithDiscount)
        {
            await getRoutingsAsync();

            ViewBag.couponCode = couponCode;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            var values = await _basketService.GetBasket();
            ViewBag.totalPrice = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.tax = tax;

            return View(values);
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);

            var items = new BasketItemDto
            {
                ProductId = values.Id,
                ProductName = values.ProductName,
                Price = values.Price,
                Quantity = 1,
                ProductImageUrl = values.ImageUrl
            };

            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}

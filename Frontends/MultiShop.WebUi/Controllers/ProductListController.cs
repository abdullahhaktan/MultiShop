using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class ProductListController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(string id)
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Ürün İşlemleri";
            HttpContext.Items["v2"] = "Ürün Listesi";

            HttpContext.Items["a0"] = "/Default/Index";
            HttpContext.Items["a1"] = "/ProductList/Index";

            ViewBag.categoryId = id;
            return View();
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            HttpContext.Items["v0"] = "Ana Sayfa";
            HttpContext.Items["v1"] = "Ürün İşlemleri";
            HttpContext.Items["v2"] = "Ürün Detayı";

            HttpContext.Items["a0"] = "/Default/Index";
            HttpContext.Items["a1"] = "/ProductList/Index";

            ViewBag.id = id;
            return View();
        }
    }
}
